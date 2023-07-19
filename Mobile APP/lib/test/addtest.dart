import 'package:dropdown_search/dropdown_search.dart';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:intl/intl.dart' as intl;
import 'package:mysql1/mysql1.dart';
import 'package:organizing_dates_examinations/classes/classes.dart';
import 'package:organizing_dates_examinations/classes/classrooms.dart';
import 'package:organizing_dates_examinations/classes/global.dart';
import 'package:organizing_dates_examinations/classes/groups.dart';
import 'package:datetime_picker_formfield_new/datetime_picker_formfield.dart';
import 'package:organizing_dates_examinations/classes/teacher_classes_groups.dart';
import 'package:organizing_dates_examinations/test/mainaddtest.dart';

class addtest extends StatefulWidget {
  addtest({super.key, required this.name, required this.id});
  String name, id;
  @override
  State<addtest> createState() => _addtestState();
}

class _addtestState extends State<addtest> {
  List<teacher_classes_groups> listteacherclassesgroups = [];
  List<Class> listclass = [];
  List<classroom> listClassrooms = [];

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

      String q = 'select * from classroom';
      results = await conn.query(q);
      if (results.isNotEmpty) {
        for (var row in results) {
          listClassrooms.add(
              classroom(id: row[0].toString(), name: row[1], type: row[3]));
        }
      }
    } catch (e) {
      print(e);
    }
    return {listteacherclassesgroups};
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: FutureBuilder(
          future: getdata(),
          builder: (context, snapshot) {
            if (snapshot.connectionState == ConnectionState.done) {
              return mainaddtest(
                id: widget.id,
                name: widget.name,
                listClassrooms: listClassrooms,
                listteacherclassesgroups: listteacherclassesgroups,
                listclass: listclass,
              );
            } else {
              return CircularProgressIndicator();
            }
          }),
    );
  }
}
