import 'package:date_time_format/date_time_format.dart';
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
import 'package:organizing_dates_examinations/classes/schedule.dart';
import 'package:organizing_dates_examinations/classes/teacher_classes_groups.dart';
import 'package:alert_dialog/alert_dialog.dart';

import '../classes/test.dart';

class mainaddtest extends StatefulWidget {
  mainaddtest(
      {super.key,
      required this.name,
      required this.id,
      required this.listteacherclassesgroups,
      required this.listClassrooms,
      required this.listclass});
  List<teacher_classes_groups> listteacherclassesgroups = [];
  List<classroom> listClassrooms = [];
  List<Class> listclass = [];
  String name, id;
  @override
  State<mainaddtest> createState() => _mainaddtestState();
}

class _mainaddtestState extends State<mainaddtest> {
  TextEditingController note = TextEditingController(),
      time = TextEditingController(),
      time1 = TextEditingController(),
      date = TextEditingController();
  String grp = "",
      clas = "",
      clasrm = "",
      day = "",
      grch = "",
      clasromnum = "",
      classidselect = "",
      groupidselected = "";
  List<test> listtest = [], listdaytest = [], listclassroomtest = [];
  List<group> listgroup = [];
  List<schedule> listschedule = [];
  late AlertDialog alert;
  bool boolgrp = false;
  int eselected = 0, sselected = 0;

  Future gettest() async {
    listtest.clear();
    var conn = await MySqlConnection.connect(con);
    var resulte = await conn.query("SELECT * FROM `test` WHERE date_test>?",
        [DateTime.now().subtract(Duration(days: 1)).format("Y/m/d")]);
    if (resulte.isNotEmpty)
      for (var row in resulte) {
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

    listgroup.clear();
    var result = await conn.query("SELECT * FROM `groups`");
    if (result.isNotEmpty) {
      for (var row in result) {
        listgroup.add(group(name: row[1].toString(), id: row[0].toString()));
      }
    }

    listschedule.clear();
    var resulte1 = await conn.query("select * from schedule");
    if (resulte1.isNotEmpty) {
      for (var row in resulte1) {
        listschedule.add(schedule(
            id_schedule: row[0].toString(),
            class_id: row[1],
            clasrm_id: row[2].toString(),
            group_id: row[3].toString(),
            day: row[4],
            time_first: row[5].toString(),
            time_end: row[6].toString()));
      }
    }
  }

  Future settest() async {
    // اضافة الى قاعدة البيانات
    try {
      var conn = await MySqlConnection.connect(con);
      var res = await conn.query(
          'INSERT INTO `test`(`teacher_id`, `class_id`, `group_id`, `clasrm_id`, `day`, `date_test`, `time_first`, `time_end`, `note`) VALUES (?,?,?,?,?,?,?,?,?)',
          [
            widget.id,
            classidselect,
            groupidselected,
            clasromnum,
            day,
            date.text,
            time.text,
            time1.text,
            note.text,
          ]);

      if (res.toString() == "()") {
        Fluttertoast.showToast(msg: "تم الاضافة");
        gettest();
      } else {
        Fluttertoast.showToast(msg: "خطأ");
      }
    } catch (e) {
      Fluttertoast.showToast(msg: e.toString());
    }
  }

  Future<bool> emptyclasroom() async {
    bool check = true;

    listclassroomtest.clear();
    for (var datest in listdaytest) {
      if (datest.id_clasrm == clasromnum) {
        listclassroomtest.add(test(
            id_test: datest.id_test.toString(),
            id_techer: datest.id_techer.toString(),
            id_clasrm: datest.id_clasrm.toString(),
            id_class: datest.id_class,
            id_group: datest.id_group.toString(),
            day: datest.day,
            datetest: date.toString(),
            timefirst: datest.timefirst.toString(),
            timeend: datest.timeend.toString(),
            note: datest.note));
      }
    }

    for (var daetest in listclassroomtest) {
      int defstart = int.parse(daetest.timefirst.split(":").first);
      int defend = int.parse(daetest.timeend.split(":").first);
      if (!(sselected >= defend || eselected <= defstart)) {
        await showDialog(
            barrierDismissible: false,
            context: context,
            builder: (context) => AlertDialog(
                  actions: [
                    TextButton(
                        onPressed: () {
                          Navigator.of(context).pop();
                          check = false;
                        },
                        child: Text("حسنا"))
                  ],
                  title: Text(
                    "تنبيه",
                    style: TextStyle(color: Colors.red),
                  ),
                  content: Text("يوجد امتحان في " +
                      clasrm +
                      " من الساعة " +
                      daetest.timefirst +
                      " الى الساعة " +
                      daetest.timeend),
                ));
      }
      if (!check) {
        break;
      }
    }
    return check;
  }

  Future<bool> emptytestgroup() async {
    bool check = true;
    Outer:
    for (var grtest in listdaytest) {
      if (groupidselected == grtest.id_group) {
        await showDialog(
            barrierDismissible: false,
            context: context,
            builder: (context) => alert = AlertDialog(
                  title: Text("تحذير", style: TextStyle(color: Colors.red)),
                  content: SizedBox(
                    height: 90,
                    child: Column(children: [
                      Text("يوجد امتحان " +
                          clas +
                          " للمجموعة من الساعة " +
                          grtest.timefirst +
                          " الى الساعة " +
                          grtest.timeend),
                      Text(
                        "هل تريد الاضافة على اي حال",
                        style: TextStyle(color: Colors.red),
                      )
                    ]),
                  ),
                  actions: [
                    TextButton(
                      child: Text("الغاء"),
                      onPressed: () {
                        Navigator.of(context).pop();
                        check = false;
                      },
                    ),
                    TextButton(
                      child: Text("استمرار"),
                      onPressed: () {
                        check = true;
                        Navigator.of(context).pop();
                      },
                    ),
                  ],
                ));
        if (!check) {
          break Outer;
        }
      }
    }
    return check;
  }

  Future<bool> emptyschedulelucher() async {
    bool check = true;
    String clashereid = "", alerttext = "";
    for (var cl in widget.listclass) if (cl.name == clas) clashereid = cl.id;
    for (var scul in listschedule) {
      if (scul.group_id == groupidselected) {
        if (scul.day == day) {
          int defstart = int.parse(scul.time_first);
          int defend = int.parse(scul.time_end);
          if (!(sselected >= defend || eselected <= defstart)) {
            if (clashereid == scul.class_id) {
              alerttext = alerttext = "يوجد لديك محاضرة " +
                  clas +
                  " للمجموعة من الساعة " +
                  scul.time_first +
                  " الى الساعة " +
                  scul.time_end;
            } else {
              alerttext = "يوجد محاضرة " +
                  clas +
                  " للمجموعة من الساعة " +
                  scul.time_first +
                  " الى الساعة " +
                  scul.time_end;
            }
            await showDialog(
                barrierDismissible: false,
                context: context,
                builder: (context) => alert = AlertDialog(
                      title: Text("تحذير", style: TextStyle(color: Colors.red)),
                      content: SizedBox(
                        height: 90,
                        child: Column(children: [
                          Text(alerttext),
                          Text(
                            "هل تريد الاضافة على اي حال",
                            style: TextStyle(color: Colors.red),
                          )
                        ]),
                      ),
                      actions: [
                        TextButton(
                          child: Text("الغاء"),
                          onPressed: () {
                            Navigator.of(context).pop();
                            check = false;
                          },
                        ),
                        TextButton(
                          child: Text("استمرار"),
                          onPressed: () {
                            check = true;
                            Navigator.of(context).pop();
                          },
                        ),
                      ],
                    ));
          }
          if (!check) {
            break;
          }
        }
      }
    }
    return check;
  }

  Future<bool> emptyschedulclassrom() async {
    bool check = true;
    for (var scul in listschedule)
      if (scul.group_id == groupidselected) if (scul.day == day) {
        if (scul.clasrm_id == clasromnum) {
          int defstart = int.parse(scul.time_first);
          int defend = int.parse(scul.time_end);
          if (!(sselected >= defend || eselected <= defstart)) {
            await showDialog(
                barrierDismissible: false,
                context: context,
                builder: (context) => alert = AlertDialog(
                      title: Text("تحذير", style: TextStyle(color: Colors.red)),
                      content: SizedBox(
                        height: 90,
                        child: Column(children: [
                          Text("يوجد محاضرة " +
                              clas +
                              " في القاعة " +
                              clasromnum),
                          Text(
                            "هل تريد الاضافة على اي حال",
                            style: TextStyle(color: Colors.red),
                          )
                        ]),
                      ),
                      actions: [
                        TextButton(
                          child: Text("الغاء"),
                          onPressed: () {
                            Navigator.of(context).pop();
                            check = false;
                          },
                        ),
                        TextButton(
                          child: Text("استمرار"),
                          onPressed: () {
                            check = true;
                            Navigator.of(context).pop();
                          },
                        ),
                      ],
                    ));
          }
          if (!check) {
            break;
          }
        }
      }
    return check;
  }

  void add() async {
    String de = "";
    listdaytest.clear();

    sselected = int.parse(time.text.split(":").first);
    eselected = int.parse(time1.text.split(":").first);

    for (int i = 0; i < widget.listclass.length; i++)
      if (widget.listclass[i].name == clas)
        classidselect = widget.listclass[i].id;
    for (var gr in widget.listteacherclassesgroups) {
      if (gr.id_class == classidselect) groupidselected = gr.id_group;
    }
    if (!(clas.isEmpty ||
        grch.isEmpty ||
        clasrm.isEmpty ||
        date.text.isEmpty ||
        time.text.isEmpty ||
        time1.text.isEmpty)) {
      //في حالةالبيانات مدخلة
      for (var clsrm in widget.listClassrooms)
        if (clsrm.type == "مدرج") {
          if (clsrm.name == clasrm) clasromnum = clsrm.id;
        } else {
          if (clsrm.id == clasrm) clasromnum = clsrm.id;
        }
      for (var datest in listtest) {
        de = datest.datetest.substring(0, datest.datetest.indexOf(" "));
        if (de == date.text) {
          setState(() {
            listdaytest.add(test(
                id_test: datest.id_test.toString(),
                id_techer: datest.id_techer.toString(),
                id_clasrm: datest.id_clasrm.toString(),
                id_class: datest.id_class,
                id_group: datest.id_group.toString(),
                day: datest.day,
                datetest: de.toString(),
                timefirst: datest.timefirst.toString(),
                timeend: datest.timeend.toString(),
                note: datest.note));
          });
        }
      }
      if (await emptyschedulclassrom()) {
        if (await emptyschedulelucher()) {
          if (listdaytest.isNotEmpty) {
            if (await emptyclasroom()) {
              if (await emptytestgroup()) {
                settest();
              }
            }
          } else {
            settest();
          }
        }
      }
    } else {
      //في حالة البيانات غير مدخلة
      showDialog(
          context: context,
          builder: (context) => AlertDialog(
                actions: [
                  TextButton(
                      onPressed: () {
                        Navigator.of(context).pop();
                      },
                      child: Text("حسنا"))
                ],
                title: Text(
                  "تنبيه",
                  style: TextStyle(color: Colors.red),
                ),
                content: Text("من فضلك املئ البيانات"),
              ));
    }
  }

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
        future: gettest(),
        builder: (context, snapshot) {
          return Scaffold(
              body: Center(
            child: SingleChildScrollView(
              child: Column(
                children: [
                  Text(widget.name),
                  SizedBox(
                    height: 15,
                  ),
                  SizedBox(
                    width: 300,
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
                        onChanged: (va) {
                          setState(() {
                            boolgrp = true;
                            clas = va;
                            for (int i = 0; i < widget.listclass.length; i++) {
                              if (widget.listclass[i].name == clas) {
                                for (var gr in listgroup) {
                                  if (gr.id ==
                                      widget.listteacherclassesgroups[i]
                                          .id_group) {
                                    grch = gr.name;
                                  }
                                }
                              }
                            }
                          });
                        },
                        items: [
                          for (int i = 0; i < widget.listclass.length; i++)
                            widget.listclass[i].name
                        ]),
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  SizedBox(
                    width: 300,
                    child: DropdownSearch(
                        selectedItem: grch,
                        enabled: boolgrp,
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
                        onChanged: (va) {
                          grp = va;
                        },
                        items: [grch]),
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  SizedBox(
                    width: 300,
                    child: DropdownSearch(
                        popupProps: PopupProps.dialog(),
                        dropdownDecoratorProps: DropDownDecoratorProps(
                            dropdownSearchDecoration: InputDecoration(
                                labelText: "القاعة",
                                labelStyle: TextStyle(
                                  color: Color.fromARGB(251, 86, 107, 224),
                                ),
                                hintTextDirection: TextDirection.ltr,
                                alignLabelWithHint: true,
                                border: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(50)))),
                        onChanged: (v) {
                          clasrm = v;
                        },
                        items: [
                          for (int i = 0; i < widget.listClassrooms.length; i++)
                            if (widget.listClassrooms[i].type == "مدرج")
                              widget.listClassrooms[i].name
                            else
                              widget.listClassrooms[i].id
                        ]),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(vertical: 15),
                    child: Container(
                      child: TextField(
                        controller: note,
                        keyboardType: TextInputType.multiline,
                        minLines: 1,
                        maxLines: 10,
                        textInputAction: TextInputAction.newline,
                        decoration: InputDecoration(
                            focusedBorder: OutlineInputBorder(
                                borderRadius: BorderRadius.circular(20),
                                borderSide: BorderSide(
                                    color: Color.fromARGB(251, 86, 107, 224))),
                            labelStyle: TextStyle(
                                color: Color.fromARGB(251, 86, 107, 224)),
                            border: OutlineInputBorder(
                                borderRadius: BorderRadius.circular(20)),
                            labelText: "ملاحظات"),
                      ),
                      width: MediaQuery.of(context).size.width / 1.4,
                    ),
                  ),
                  Container(
                    width: MediaQuery.of(context).size.width / 1.4,
                    child: DateTimeField(
                      controller: date,
                      decoration: InputDecoration(
                          focusedBorder: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(20),
                              borderSide: BorderSide(
                                  color: Color.fromARGB(251, 86, 107, 224))),
                          labelText: "تاريخ الامتحان",
                          labelStyle: TextStyle(
                              color: Color.fromARGB(251, 86, 107, 224)),
                          border: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(20))),
                      format: intl.DateFormat("yyyy-MM-dd"),
                      onShowPicker: (context, currentValue) {
                        return showDatePicker(
                            context: context,
                            firstDate: DateTime.now(),
                            initialDate: currentValue ?? DateTime.now(),
                            lastDate: DateTime.now().add(Duration(days: 90)));
                      },
                      onChanged: (value) {
                        DateTime d = value ?? DateTime.now();
                        setState(() {
                          day = intl.DateFormat("EEEE").format(d);
                        });
                      },
                    ),
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Padding(
                        padding: const EdgeInsets.symmetric(vertical: 15),
                        child: Container(
                          width: MediaQuery.of(context).size.width / 3.0,
                          child: TextField(
                            controller: time,
                            readOnly: true,
                            onTap: () async {
                              TimeOfDay? t;
                              while (true) {
                                t = await showTimePicker(
                                  context: context,
                                  initialTime: TimeOfDay(hour: 8, minute: 00),
                                  builder: (context, childWidget) {
                                    return MediaQuery(
                                      child: childWidget!,
                                      data: MediaQuery.of(context).copyWith(
                                        alwaysUse24HourFormat: true,
                                      ),
                                    );
                                  },
                                );
                                if (t == null) {
                                  break;
                                }
                                if (t!.hour <= 16 && t!.hour >= 8) {
                                  break;
                                }
                                if (t!.hour >= 16) {
                                  Fluttertoast.showToast(
                                      msg:
                                          "لا يمكن ان تبدأ الامتحان بعد نهاية دوام العمل");
                                } else {
                                  Fluttertoast.showToast(
                                      msg: "لايمكن ان تبدأ امتحان قبل الدوام ");
                                }
                              }
                              setState(() {
                                if (t != null)
                                  time.text = t.hour.toString() +
                                      ":" +
                                      t.minute.toString();
                              });
                            },
                            decoration: InputDecoration(
                                focusedBorder: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(20),
                                    borderSide: BorderSide(
                                        color:
                                            Color.fromARGB(251, 86, 107, 224))),
                                labelText: "وقت  بداية الامتحان",
                                labelStyle: TextStyle(
                                    fontSize: 12,
                                    color: Color.fromARGB(251, 86, 107, 224)),
                                border: OutlineInputBorder(
                                    borderSide: BorderSide(
                                      color: Color.fromARGB(251, 86, 107, 224),
                                    ),
                                    borderRadius: BorderRadius.circular(20))),
                          ),
                        ),
                      ),
                      SizedBox(
                        width: 10,
                      ),
                      Padding(
                        padding: const EdgeInsets.symmetric(vertical: 15),
                        child: Container(
                          width: MediaQuery.of(context).size.width / 3.0,
                          child: TextField(
                            controller: time1,
                            readOnly: true,
                            onTap: () async {
                              TimeOfDay? t1;
                              while (true) {
                                t1 = await showTimePicker(
                                  context: context,
                                  initialTime: TimeOfDay(hour: 8, minute: 00),
                                  builder: (context, childWidget) {
                                    return MediaQuery(
                                      child: childWidget!,
                                      data: MediaQuery.of(context).copyWith(
                                        alwaysUse24HourFormat: true,
                                      ),
                                    );
                                  },
                                );
                                if (t1 == null) {
                                  break;
                                }
                                if (t1!.hour <= 18 && t1!.hour >= 9) {
                                  break;
                                }
                                if (t1!.hour >= 18) {
                                  Fluttertoast.showToast(
                                      msg:
                                          "لا يمكن ان تنهي الامتحان بعد نهاية دوام العمل");
                                } else {
                                  Fluttertoast.showToast(
                                      msg: "لايمكن ان تنهي امتحان قبل الدوام ");
                                }
                              }
                              setState(() {
                                if (t1 != null)
                                  time1.text = t1.hour.toString() +
                                      ":" +
                                      t1.minute.toString();
                              });
                            },
                            decoration: InputDecoration(
                                focusedBorder: OutlineInputBorder(
                                    borderRadius: BorderRadius.circular(20),
                                    borderSide: BorderSide(
                                        color:
                                            Color.fromARGB(251, 86, 107, 224))),
                                labelText: "وقت نهاية الامتحان",
                                labelStyle: TextStyle(
                                    fontSize: 12,
                                    color: Color.fromARGB(251, 86, 107, 224)),
                                border: OutlineInputBorder(
                                    borderSide: BorderSide(
                                      color: Color.fromARGB(251, 86, 107, 224),
                                    ),
                                    borderRadius: BorderRadius.circular(20))),
                          ),
                        ),
                      ),
                    ],
                  ),
                  SizedBox(
                    width: 100,
                    child: ElevatedButton(
                        style: ElevatedButton.styleFrom(
                            primary: Color.fromARGB(251, 86, 107, 224),
                            shape: ContinuousRectangleBorder(
                                borderRadius: BorderRadius.circular(150))),
                        onPressed: () {
                          add();
                        },
                        child: Text("اضافة")),
                  )
                ],
              ),
            ),
          ));
        });
  }
}
