import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:mysql1/mysql1.dart';
import 'package:organizing_dates_examinations/classes/student.dart';
import 'package:organizing_dates_examinations/home.dart';
import 'package:organizing_dates_examinations/viewStudent.dart';
import 'classes/global.dart';

class login extends StatefulWidget {
  const login({super.key});

  @override
  State<login> createState() => _loginState();
}

class _loginState extends State<login> {
  bool eye = true, a = true, b = false;
  int x = 0;
  String erpassTeacher = "", erpassStudent = "";
  TextEditingController usernameTeacher = TextEditingController(),
      passwordTeacher = TextEditingController(),
      usernameStudent = TextEditingController(),
      passwordStudent = TextEditingController();
  Color stud = Color.fromARGB(250, 158, 171, 243),
      teach = Color.fromARGB(251, 86, 107, 224);

  List<student> liststudent = [];

  Future getdataTeacher(String name, String pass, context) async {
    try {
      var conn = await MySqlConnection.connect(con);
      var results = await conn
          .query('select * from teacher where user_name=? ', [name.trim()]);
      if (results.isNotEmpty) {
        setState(() {
          erpassTeacher = "";
        });
        var data;
        for (var row in results) {
          data = row;
        }
        if (data[3] == pass) {
          setState(() {
            erpassTeacher = "";
            Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => home(name: data[1], id: data[0].toString()),
            ));
          });
        } else
          setState(() {
            erpassTeacher = "البيانات غير صحيحة";
          });
      } else {
        setState(() {
          erpassTeacher = "البيانات غير صحيحة";
        });
        ;
      }
    } catch (e) {
      Fluttertoast.showToast(msg: e.toString());
    }
  }

  Future getdataStudent(String name, String pass, context) async {
    try {
      x = 0;
      var conn = await MySqlConnection.connect(con);
      var results = await conn.query(
          'select id_student,name from student where name=? ', [name.trim()]);
      if (results.isNotEmpty) {
        setState(() {
          erpassStudent = "";
        });
        var data;
        for (var row in results) {
          data = row;
        }
        if (data[0].toString() == pass) {
          var res = await conn.query(
              "select * from student_classes where student_id=?",
              [data[0].toString()]);
          for (var da in res) {
            x++;
            liststudent.add(student(
                class_id: da[1].toString(), bef_class: da[2].toString()));
          }
          setState(() {
            erpassStudent = "";
            Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => viewStudent(
                  name: data[1],
                  id: data[0].toString(),
                  liststudent: liststudent,
                  x: x),
            ));
          });
        } else
          setState(() {
            erpassStudent = "البيانات غير صحيحة";
          });
      } else {
        setState(() {
          erpassStudent = "البيانات غير صحيحة";
        });
        ;
      }
    } catch (e) {
      Fluttertoast.showToast(msg: e.toString());
    }
  }

  Future<bool> pop() async {
    return false;
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: pop,
      child: Scaffold(
        body: Center(
          child: SingleChildScrollView(
            child:
                Column(mainAxisAlignment: MainAxisAlignment.center, children: [
              Center(
                  child: SizedBox(
                child: Image.asset("assets/images/CCTT.png"),
                width: 200,
                height: 200,
              )),
              Text(
                "تنظيم مواعيد الامتحانات",
                style: TextStyle(fontSize: 32),
              ),
              SizedBox(
                height: 50,
              ),
              Row(mainAxisAlignment: MainAxisAlignment.center, children: [
                TextButton(
                    style: TextButton.styleFrom(primary: teach),
                    onPressed: () {
                      setState(() {
                        erpassStudent = "";
                        usernameStudent.text = "";
                        passwordStudent.text = "";
                        a = true;
                        b = false;
                        stud = Color.fromARGB(250, 158, 171, 243);
                        teach = Color.fromARGB(251, 86, 107, 224);
                      });
                    },
                    child: Text("عضو هيئة التدريس")),
                TextButton(
                    style: TextButton.styleFrom(primary: stud),
                    onPressed: () {
                      setState(() {
                        erpassTeacher = "";
                        usernameTeacher.text = "";
                        passwordTeacher.text = "";
                        a = false;
                        b = true;
                        stud = Color.fromARGB(251, 86, 107, 224);
                        teach = Color.fromARGB(250, 158, 171, 243);
                      });
                    },
                    child: Text("طالب"))
              ]),
              SizedBox(
                height: 20,
              ),
              Visibility(
                  //عضو هيئة التدريس
                  visible: a,
                  child: Column(
                    children: [
                      Container(
                        child: TextField(
                          controller: usernameTeacher,
                          decoration: InputDecoration(
                              border: OutlineInputBorder(
                                  borderRadius: BorderRadius.circular(20)),
                              labelText: "اسم المستخدم"),
                        ),
                        width: MediaQuery.of(context).size.width / 1.5,
                        height: 50,
                      ),
                      SizedBox(
                        height: 30,
                      ),
                      Container(
                        child: TextField(
                          controller: passwordTeacher,
                          decoration: InputDecoration(
                            border: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(20),
                            ),
                            labelText: "رمز المرور",
                            suffix: IconButton(
                              onPressed: () {
                                setState(() {
                                  eye = !eye;
                                });
                              },
                              icon: Icon(
                                Icons.remove_red_eye_outlined,
                                color: Colors.grey,
                              ),
                            ),
                            counterText: "",
                          ),
                          obscureText: eye,
                          maxLength: 20,
                        ),
                        width: MediaQuery.of(context).size.width / 1.5,
                        height: 50,
                      ),
                      SizedBox(
                        child: Text(
                          erpassTeacher,
                          style: TextStyle(color: Colors.red),
                        ),
                        height: 30,
                      ),
                      Container(
                          child: ElevatedButton(
                        onPressed: () {
                          getdataTeacher(usernameTeacher.text,
                              passwordTeacher.text, context);
                        },
                        child: Text("دخول"),
                        style: ElevatedButton.styleFrom(
                            primary: Color.fromARGB(251, 86, 107, 224),
                            fixedSize: Size(90, 40),
                            shape: ContinuousRectangleBorder(
                                borderRadius: BorderRadius.circular(150))),
                      )),
                    ],
                  )),
              Visibility(
                  //طالب
                  visible: b,
                  child: Column(
                    children: [
                      Container(
                        child: TextField(
                          controller: usernameStudent,
                          decoration: InputDecoration(
                              border: OutlineInputBorder(
                                  borderRadius: BorderRadius.circular(20)),
                              labelText: "الاسم"),
                        ),
                        width: MediaQuery.of(context).size.width / 1.5,
                        height: 50,
                      ),
                      SizedBox(
                        height: 30,
                      ),
                      Container(
                        child: TextField(
                          controller: passwordStudent,
                          decoration: InputDecoration(
                            border: OutlineInputBorder(
                              borderRadius: BorderRadius.circular(20),
                            ),
                            labelText: "رقم القيد",
                            suffix: IconButton(
                              onPressed: () {
                                setState(() {
                                  eye = !eye;
                                });
                              },
                              icon: Icon(
                                Icons.remove_red_eye_outlined,
                                color: Colors.grey,
                              ),
                            ),
                            counterText: "",
                          ),
                          obscureText: eye,
                          maxLength: 20,
                        ),
                        width: MediaQuery.of(context).size.width / 1.5,
                        height: 50,
                      ),
                      SizedBox(
                        child: Text(
                          erpassStudent,
                          style: TextStyle(color: Colors.red),
                        ),
                        height: 30,
                      ),
                      Container(
                          child: ElevatedButton(
                        onPressed: () {
                          getdataStudent(usernameStudent.text,
                              passwordStudent.text, context);
                        },
                        child: Text("دخول"),
                        style: ElevatedButton.styleFrom(
                            primary: Color.fromARGB(251, 86, 107, 224),
                            fixedSize: Size(90, 40),
                            shape: ContinuousRectangleBorder(
                                borderRadius: BorderRadius.circular(150))),
                      )),
                    ],
                  )),
              SizedBox(
                height: 100,
              ),
            ]),
          ),
        ),
      ),
    );
  }
}
