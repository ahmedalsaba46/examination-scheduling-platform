import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:mysql1/mysql1.dart';
import 'package:organizing_dates_examinations/classes/global.dart';
import 'package:organizing_dates_examinations/classes/student.dart';
import 'package:organizing_dates_examinations/classes/test.dart';

class viewStudent extends StatefulWidget {
  viewStudent(
      {super.key,
      required this.name,
      required this.id,
      required this.liststudent,
      required this.x});
  String name, id;
  int x;
  List<student> liststudent;
  @override
  State<viewStudent> createState() => _viewStudentState();
}

class _viewStudentState extends State<viewStudent> {
  List<test> listtest = [];
  Future gettest() async {
    var conn = await MySqlConnection.connect(con);
    try {
      listtest.clear();
      for (int i = 0; i < widget.x; i++) {
        var resulte = await conn.query("select * from test where class_id=?",
            [widget.liststudent[i].class_id]);
        if (resulte.isNotEmpty) {
          for (var row in resulte) {
            List<String> l = row[6].toString().split(' ');
            listtest.add(test(
                id_test: row[0].toString(),
                id_techer: row[1].toString(),
                id_clasrm: row[4].toString(),
                id_class: row[2],
                id_group: row[3].toString(),
                day: row[5],
                datetest: l[0].toString(),
                timefirst: row[7].toString(),
                timeend: row[8].toString(),
                note: row[9]));
          }
        }
      }
    } catch (e) {
      Fluttertoast.showToast(msg: e.toString());
    }
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
        future: gettest(),
        builder: (context, snapshot) {
          return Scaffold(
              body: Center(
            child: Container(
              width: MediaQuery.of(context).size.width / 1.2,
              child: Table(
                border: TableBorder.all(),
                children: [
                  TableRow(
                    children: [
                      Text(
                        "المادة",
                      ),
                      Text("القاعة"),
                      Text("التاريخ"),
                      Text("اليوم"),
                      Text("الساعة"),
                      Text("ملاحظة"),
                    ],
                  ),
                  for (int i = 0; i < listtest.length; i++)
                    TableRow(
                      children: [
                        Text(listtest[i].id_class),
                        Text(listtest[i].id_clasrm),
                        Text(listtest[i].datetest),
                        Text(listtest[i].day),
                        Text(listtest[i].timefirst +
                            " الى " +
                            listtest[i].timeend),
                        Text(listtest[i].note),
                      ],
                    )
                ],
              ),
            ),
          ));
        });
  }
}
