import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:organizing_dates_examinations/login.dart';
import 'package:organizing_dates_examinations/test/addtest.dart';
import 'package:organizing_dates_examinations/test/edittest.dart';
import 'package:organizing_dates_examinations/test/removetest.dart';

class test extends StatefulWidget {
  test({super.key, required this.page, required this.name, required this.id});
  int page;
  String name, id;
  @override
  State<test> createState() => _testState();
}

class _testState extends State<test> {
  Future<bool> pop() async {
    return false;
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: pop,
      child: DefaultTabController(
        length: 3,
        initialIndex: widget.page,
        child: Scaffold(
            appBar: AppBar(
              leading: Container(),
              backgroundColor: Color.fromARGB(251, 86, 107, 224),
              systemOverlayStyle: SystemUiOverlayStyle(
                  systemNavigationBarColor: Color.fromARGB(251, 86, 107, 224)),
              title: Row(
                mainAxisAlignment: MainAxisAlignment.end,
                children: [
                  Text(
                    "تنظيم مواعيد الامتحانات",
                    style: TextStyle(color: Colors.black),
                  ),
                  SizedBox(
                    width: 40,
                  ),
                  IconButton(
                      onPressed: () {
                        Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => login(),
                        ));
                      },
                      icon: Icon(
                        Icons.logout,
                        color: Colors.red,
                      )),
                ],
              ),
              bottom: TabBar(isScrollable: true, tabs: [
                Tab(
                  text: "اضافة امتحان",
                ),
                Tab(text: "تعديل بيانات امتحان"),
                Tab(
                  text: "حذف امتحان",
                )
              ]),
            ),
            body: TabBarView(children: [
              addtest(name: widget.name, id: widget.id),
              edittest(name: widget.name, id: widget.id),
              removetest(name: widget.name, id: widget.id)
            ])),
      ),
    );
  }
}
