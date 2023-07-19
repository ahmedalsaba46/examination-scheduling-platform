import "package:date_time_format/date_time_format.dart";
import "package:datetime_picker_formfield_new/datetime_picker_formfield.dart";
import "package:dropdown_search/dropdown_search.dart";
import "package:flutter/material.dart";
import "package:fluttertoast/fluttertoast.dart";
import "package:intl/intl.dart" as intl;
import "package:mysql1/mysql1.dart";
import "package:organizing_dates_examinations/classes/classes.dart";
import "package:organizing_dates_examinations/classes/classrooms.dart";
import "package:organizing_dates_examinations/classes/global.dart";
import "package:organizing_dates_examinations/classes/groups.dart";
import "package:organizing_dates_examinations/classes/schedule.dart";
import "package:organizing_dates_examinations/classes/test.dart";
import "../classes/teacher_classes_groups.dart";

class edittest extends StatefulWidget {
  edittest({super.key, required this.name, required this.id});
  String name, id;
  @override
  State<edittest> createState() => _edittestState();
}

class _edittestState extends State<edittest> {
  TextEditingController note = TextEditingController(),
      time = TextEditingController(),
      time1 = TextEditingController(),
      date = TextEditingController();

  String grp = "",
      clas = "",
      clasrm = "",
      day = "",
      testch = "1",
      grpid = "",
      testselect = "",
      grpsselect = "",
      classidselect = "",
      groupidselected = "",
      clasromnum = "",
      idacheletest = "",
      idgroup = "";
  List<teacher_classes_groups> listteacherclassesgroups = [];
  List<Class> listclass = [];
  List<classroom> listClassrooms = [];
  List<test> listtesttecher = [],
      listtest = [],
      listdaytest = [],
      listclassroomtest = [];
  List<group> listgroup = [];
  List<schedule> listschedule = [];
  int y = 0, sselected = 0, eselected = 0;
  bool engrp = false, entest = false, data = false, enbutton = false;
  late AlertDialog alert;

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

      listgroup.clear();
      var result = await conn.query("SELECT * FROM `groups`");
      if (result.isNotEmpty) {
        for (var row in result) {
          listgroup.add(group(name: row[1].toString(), id: row[0].toString()));
        }
      }

      listtest.clear();
      conn = await MySqlConnection.connect(con);
      var resulte1 = await conn.query("SELECT * FROM `test` WHERE date_test>?",
          [DateTime.now().subtract(Duration(days: 1)).format("Y/m/d")]);
      if (resulte1.isNotEmpty)
        for (var row in resulte1) {
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

      listschedule.clear();
      var resulte2 = await conn.query("select * from schedule");
      if (resulte2.isNotEmpty) {
        for (var row in resulte2) {
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
    } catch (e) {
      Fluttertoast.showToast(msg: e.toString());
    }
    return {listteacherclassesgroups};
  }

  Future gettests() async {
    listtesttecher.clear();
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
      listtesttecher.add(test(
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
    for (var cl in listclass) if (cl.name == clas) clashereid = cl.id;
    for (var scul in listschedule) {
      if (scul.group_id == idgroup) {
        if (scul.day == day) {
          int defstart = int.parse(scul.time_first.split(":").first);
          int defend = int.parse(scul.time_end.split(":").first);
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
      if (scul.group_id == idgroup) if (scul.day == day) {
        if (scul.clasrm_id == clasromnum) {
          int defstart = int.parse(scul.time_first.split(":").first);
          int defend = int.parse(scul.time_end.split(":").first);
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

  Future setupdate() async {
    try {
      var conn = await MySqlConnection.connect(con);
      var resulte = await conn.query(
          "UPDATE `test` SET `teacher_id`=?,`class_id`=?,`group_id`=?,`clasrm_id`=?,`day`=?,`date_test`=?,`time_first`=?,`time_end`=?,`note`=? WHERE id_test=?",
          [
            widget.id,
            listtesttecher[int.parse(testch) - 1].id_class,
            idgroup,
            clasromnum,
            day,
            date.text,
            time.text,
            time1.text,
            note.text,
            listtesttecher[int.parse(testch) - 1].id_test
          ]);
      if (resulte.toString() == "()") {
        Fluttertoast.showToast(msg: "تم التعديل");
        gettests();
        setState(() {
          engrp = false;
          entest = false;
          data = false;
          enbutton = false;
        });
      } else {
        Fluttertoast.showToast(msg: "خطأ");
      }
    } catch (e) {
      Fluttertoast.showToast(msg: e.toString());
    }
  }

  Future update() async {
    String de = "";
    listdaytest.clear();

    sselected = int.parse(time.text.split(":").first);
    eselected = int.parse(time1.text.split(":").first);

    for (int i = 0; i < listclass.length; i++)
      if (listtesttecher[int.parse(testch) - 1].id_class == listclass[i].id)
        idgroup = listteacherclassesgroups[i].id_group;

    for (int i = 0; i < listtest.length; i++) {
      if (idacheletest == listtest[i].id_test) {
        listtest.remove(i);
      }
    }

    for (int i = 0; i < listclass.length; i++)
      if (listclass[i].name == clas) classidselect = listclass[i].id;
    for (var gr in listteacherclassesgroups) {
      if (gr.id_class == classidselect) groupidselected = gr.id_group;
    }

    for (var clsrm in listClassrooms)
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
    if (!(clas.isEmpty ||
        grp.isEmpty ||
        clasrm.isEmpty ||
        date.text.isEmpty ||
        time.text.isEmpty ||
        time1.text.isEmpty)) {
      if (await emptyschedulclassrom()) {
        if (await emptyschedulelucher()) {
          if (listdaytest.isNotEmpty) {
            if (await emptyclasroom()) {
              if (await emptytestgroup()) {
                setupdate();
              }
            }
          } else {
            setupdate();
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
                          data = false;
                          enbutton = false;
                          for (int i = 0; i < listclass.length; i++) {
                            if (listclass[i].name == clas) {
                              for (var gr in listgroup) {
                                if (gr.id ==
                                    listteacherclassesgroups[i].id_group) {
                                  grpsselect = gr.name;
                                }
                              }
                            }
                          }
                          testselect = "";
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
                      selectedItem: grpsselect,
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
                          data = false;
                          enbutton = false;
                        });
                      },
                      items: [grpsselect]),
                ),
                DropdownSearch(
                    selectedItem: testselect,
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
                        data = true;
                        enbutton = true;
                        testch = v.toString();
                        idacheletest =
                            listtesttecher[int.parse(testch) - 1].id_test;
                        note.text = listtesttecher[int.parse(testch) - 1].note;
                        date.text = DateTime.tryParse(
                                listtesttecher[int.parse(testch) - 1].datetest)!
                            .toLocal()
                            .format("Y-m-d");
                        time.text =
                            listtesttecher[int.parse(testch) - 1].timefirst;
                        time1.text =
                            listtesttecher[int.parse(testch) - 1].timeend;
                        for (int i = 0; i < listClassrooms.length; i++)
                          if (listClassrooms[i].id ==
                              listtesttecher[int.parse(testch) - 1]
                                  .id_clasrm) if (listClassrooms[i].type ==
                              "مدرج")
                            clasrm = listClassrooms[i].name;
                          else
                            clasrm = listClassrooms[i].id;
                      });
                    },
                    items: [for (int i = 0; i < y; i++) i + 1]),
              ]),
            ),
            SizedBox(
              height: 15,
            ),
            SizedBox(
              width: MediaQuery.of(context).size.width / 1.4,
              child: DropdownSearch(
                  selectedItem: clasrm,
                  enabled: data,
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
                    setState(() {
                      clasrm = v;
                    });
                  },
                  items: [
                    for (int i = 0; i < listClassrooms.length; i++)
                      if (listClassrooms[i].type == "مدرج")
                        listClassrooms[i].name
                      else
                        listClassrooms[i].id
                  ]),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(vertical: 15),
              child: Container(
                child: TextField(
                  controller: note,
                  enabled: data,
                  keyboardType: TextInputType.multiline,
                  minLines: 1,
                  maxLines: 10,
                  textInputAction: TextInputAction.newline,
                  decoration: InputDecoration(
                      focusedBorder: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(20),
                          borderSide: BorderSide(
                              color: Color.fromARGB(251, 86, 107, 224))),
                      labelStyle:
                          TextStyle(color: Color.fromARGB(251, 86, 107, 224)),
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
                enabled: data,
                decoration: InputDecoration(
                    focusedBorder: OutlineInputBorder(
                        borderRadius: BorderRadius.circular(20),
                        borderSide: BorderSide(
                            color: Color.fromARGB(251, 86, 107, 224))),
                    labelText: "تاريخ الامتحان",
                    labelStyle:
                        TextStyle(color: Color.fromARGB(251, 86, 107, 224)),
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
                      enabled: data,
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
                                    "لا يمكن ان يبدأ الامتحان بعد نهاية دوام العمل");
                          } else {
                            Fluttertoast.showToast(
                                msg: "لايمكن ان يبدأ امتحان قبل الدوام ");
                          }
                        }
                        setState(() {
                          if (t != null)
                            time.text =
                                t.hour.toString() + ":" + t.minute.toString();
                        });
                      },
                      decoration: InputDecoration(
                          focusedBorder: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(20),
                              borderSide: BorderSide(
                                  color: Color.fromARGB(251, 86, 107, 224))),
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
                      enabled: data,
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
                            time1.text =
                                t1.hour.toString() + ":" + t1.minute.toString();
                        });
                      },
                      decoration: InputDecoration(
                          focusedBorder: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(20),
                              borderSide: BorderSide(
                                  color: Color.fromARGB(251, 86, 107, 224))),
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
            ElevatedButton(
                style: ElevatedButton.styleFrom(
                    primary: Color.fromARGB(251, 86, 107, 224),
                    shape: ContinuousRectangleBorder(
                        borderRadius: BorderRadius.circular(150))),
                onPressed: enbutton
                    ? () {
                        update();
                      }
                    : null,
                child: Text("تعديل"))
          ]),
        )));
      },
    );
  }
}
