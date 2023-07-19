import 'package:dropdown_search/dropdown_search.dart';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:intl/intl.dart' as intl;
import 'package:mysql1/mysql1.dart';
import 'package:organizing_dates_examinations/classes/classes.dart';
import 'package:organizing_dates_examinations/classes/classrooms.dart';
import 'package:organizing_dates_examinations/classes/global.dart';
import 'package:organizing_dates_examinations/classes/groups.dart';
import 'package:organizing_dates_examinations/classes/teacher_classes_groups.dart';
import 'package:organizing_dates_examinations/classes/test.dart';

class removetest extends StatefulWidget {
  removetest({super.key, required this.name, required this.id});
  String name, id;
  @override
  State<removetest> createState() => _removetestState();
}

class _removetestState extends State<removetest> {
  String grp = "",
      clas = "",
      clasrm = "",
      testch = "1",
      textclasroom = "",
      textdate = "",
      texttimefirst = "",
      texttimeend = "",
      textnote = "",
      groupselected = "";
  bool engrp = false, entest = false, enbutton = false;
  List<teacher_classes_groups> listteacherclassesgroups = [];
  List<Class> listclass = [];
  List<classroom> listClassrooms = [];
  List<test> listtest = [];
  List<group> listgroup = [];
  int y = 1;
  Future getdata() async {
    //جلب البيانات من قاعدة البيانات
    try {
      var conn = await MySqlConnection.connect(con);
      listteacherclassesgroups.clear();
      listclass.clear();
      listClassrooms.clear();

      var results = await conn.query(
          'select * from teacher_classes_groups where teacher_id=?',
          [widget.id]);
      if (results.isNotEmpty) {
        for (var row in results) {
          listteacherclassesgroups.add(teacher_classes_groups(
              id_class: row[2],
              id_group: row[0].toString(),
              id_teacher: row[1].toString()));
          var resul = await conn
              .query('select * from classes where id_class=?', [row[2]]);
          for (var r in resul) listclass.add(Class(name: r[1], id: r[0]));
        }
      }

      var resul = await conn.query('select * from groups');
      if (resul.isNotEmpty) {
        for (var row in resul) {
          listgroup.add(group(name: row[1], id: row[0].toString()));
        }
      }

      String q = 'select * from classroom';
      results = await conn.query(q);
      if (results.isNotEmpty) {
        for (var row in results) {
          listClassrooms.add(
              classroom(id: row[0].toString(), name: row[1], type: row[3]));
        }
      }
    } catch (e) {
      Fluttertoast.showToast(msg: e.toString());
    }
    return {listteacherclassesgroups};
  }

  Future gettests() async {
    listtest.clear();
    var conn = await MySqlConnection.connect(con);
    var resulte = await conn.query(
        "select * from test where teacher_id=? and class_id=? and group_id=?", [
      widget.id,
      for (int i = 0; i < listclass.length; i++)
        if (listclass[i].name == clas) listclass[i].id,
      for (int i = 0; i < listclass.length; i++)
        if (listclass[i].name == clas) listteacherclassesgroups[i].id_group
    ]);
    y = 0;
    for (var row in resulte) {
      y++;

      listtest.add(test(
          id_test: row[0].toString(),
          id_techer: row[1].toString(),
          id_clasrm: row[4].toString(),
          id_class: row[2],
          id_group: row[3].toString(),
          day: row[5],
          datetest: row[6].toString(),
          timefirst: row[7].toString(),
          timeend: row[8].toString(),
          note: row[9]));
    }
    setState(() {
      y;
    });
  }

  Future remove() async {
    try {
      var conn = await MySqlConnection.connect(con);
      var resulte = await conn.query("delete from `test` where id_test = ?",
          [listtest[int.parse(testch) - 1].id_test.toString()]);

      if (resulte.toString() == "()") {
        Fluttertoast.showToast(msg: "تم الحذف");
        setState(() {
          engrp = false;
          entest = false;
          enbutton = false;
          textnote = "";
          textdate = "";
          texttimefirst = "";
          texttimeend = "";
          textclasroom = "";
        });
      } else {
        Fluttertoast.showToast(msg: "خطأ");
      }
    } catch (e) {
      Fluttertoast.showToast(msg: e.toString());
    }
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
      future: getdata(),
      builder: (context, snapshot) {
        return Scaffold(
            body: Center(
                child: SingleChildScrollView(
                    child: Column(children: [
          Text(widget.name),
          Container(
            width: MediaQuery.of(context).size.width / 1.4,
            height: 250,
            decoration: BoxDecoration(
                color: Color.fromARGB(50, 166, 204, 248),
                borderRadius: BorderRadius.circular(30)),
            child: Column(children: [
              Padding(
                padding: const EdgeInsets.only(right: 15),
                child: Row(
                  children: [
                    Text("اختيار الامتحان"),
                  ],
                ),
              ),
              Padding(
                padding: const EdgeInsets.only(top: 10),
                child: DropdownSearch(
                    popupProps: PopupProps.dialog(),
                    dropdownDecoratorProps: DropDownDecoratorProps(
                        dropdownSearchDecoration: InputDecoration(
                            labelText: "المادة",
                            labelStyle: TextStyle(
                              color: Color.fromARGB(251, 86, 107, 224),
                            ),
                            hintTextDirection: TextDirection.ltr,
                            alignLabelWithHint: true,
                            border: OutlineInputBorder(
                                borderRadius: BorderRadius.circular(50)))),
                    onChanged: (v) {
                      setState(() {
                        clas = v;
                        engrp = true;
                        entest = false;
                        enbutton = false;
                        textnote = "";
                        textdate = "";
                        texttimefirst = "";
                        texttimeend = "";
                        textclasroom = "";
                        for (int i = 0; i < listclass.length; i++) {
                          if (listclass[i].name == clas) {
                            for (var gr in listgroup) {
                              if (gr.id ==
                                  listteacherclassesgroups[i].id_group) {
                                groupselected = gr.name;
                              }
                            }
                          }
                        }
                      });
                    },
                    items: [
                      for (int i = 0; i < listclass.length; i++)
                        listclass[i].name
                    ]),
              ),
              Padding(
                padding: const EdgeInsets.symmetric(vertical: 10),
                child: DropdownSearch(
                    enabled: engrp,
                    selectedItem: groupselected,
                    popupProps: PopupProps.dialog(),
                    dropdownDecoratorProps: DropDownDecoratorProps(
                        dropdownSearchDecoration: InputDecoration(
                            labelText: "المجموعة",
                            labelStyle: TextStyle(
                              color: Color.fromARGB(251, 86, 107, 224),
                            ),
                            hintTextDirection: TextDirection.ltr,
                            alignLabelWithHint: true,
                            border: OutlineInputBorder(
                                borderRadius: BorderRadius.circular(50)))),
                    onChanged: (v) {
                      setState(() {
                        grp = v;
                        gettests();
                        entest = true;
                        enbutton = false;
                        textnote = "";
                        textdate = "";
                        texttimefirst = "";
                        texttimeend = "";
                        textclasroom = "";
                      });
                    },
                    items: [groupselected]),
              ),
              DropdownSearch(
                  enabled: entest,
                  popupProps: PopupProps.dialog(),
                  dropdownDecoratorProps: DropDownDecoratorProps(
                      dropdownSearchDecoration: InputDecoration(
                          labelText: "امتحان",
                          labelStyle: TextStyle(
                            color: Color.fromARGB(251, 86, 107, 224),
                          ),
                          hintTextDirection: TextDirection.ltr,
                          alignLabelWithHint: true,
                          border: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(50)))),
                  onChanged: (v) {
                    setState(() {
                      testch = v.toString();
                      textnote = listtest[int.parse(testch) - 1].note;
                      List<String> s =
                          listtest[int.parse(testch) - 1].datetest.split(' ');
                      textdate = s[0];
                      texttimefirst = listtest[int.parse(testch) - 1].timefirst;
                      texttimeend = listtest[int.parse(testch) - 1].timeend;
                      for (int i = 0; i < listClassrooms.length; i++)
                        if (listClassrooms[i].id ==
                            listtest[int.parse(testch) - 1]
                                .id_clasrm) if (listClassrooms[i].type ==
                            "مدرج")
                          textclasroom = listClassrooms[i].name;
                        else
                          textclasroom = listClassrooms[i].id;

                      enbutton = true;
                    });
                  },
                  items: [for (int i = 0; i < y; i++) i + 1]),
            ]),
          ),
          SizedBox(
            height: 15,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text("قاعة: "),
              Text(textclasroom),
            ],
          ),
          SizedBox(
            height: 15,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text("ملاحظات: "),
              Text(textnote),
            ],
          ),
          SizedBox(
            height: 15,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text("التاريخ: "),
              Text(textdate),
            ],
          ),
          SizedBox(
            height: 15,
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text("الوقت: من "),
              Text(texttimefirst),
              Text("الى"),
              Text(texttimeend),
            ],
          ),
          ElevatedButton(
              style: ElevatedButton.styleFrom(
                  primary: Color.fromARGB(251, 86, 107, 224),
                  shape: ContinuousRectangleBorder(
                      borderRadius: BorderRadius.circular(150))),
              onPressed: enbutton
                  ? () {
                      remove();
                    }
                  : null,
              child: Text("حذف"))
        ]))));
      },
    );
  }
}
