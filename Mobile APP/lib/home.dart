import 'package:flutter/material.dart';
import 'package:organizing_dates_examinations/test.dart';

class home extends StatefulWidget {
  home({super.key, required this.name, required this.id});
  String name, id;
  @override
  State<home> createState() => _homeState();
}

class _homeState extends State<home> {
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
                  child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
            Center(
                child: SizedBox(
              child: Image.asset("assets/images/CCTT.png"),
              width: 100,
              height: 100,
            )),
            Text(
              "تنظيم مواعيد الامتحانات",
              style: TextStyle(fontSize: 20),
            ),
            SizedBox(
              height: 150,
            ),
            Container(
                child: ElevatedButton(
              onPressed: () {
                setState(() {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) =>
                        test(page: 0, name: widget.name, id: widget.id),
                  ));
                });
              },
              child: Text("اضافة امتحان"),
              style: ElevatedButton.styleFrom(
                  primary: Color.fromARGB(251, 86, 107, 224),
                  fixedSize: Size(180, 40),
                  shape: ContinuousRectangleBorder(
                      borderRadius: BorderRadius.circular(150))),
            )),
            SizedBox(
              height: 25,
            ),
            Container(
                child: ElevatedButton(
              onPressed: () {
                setState(() {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) =>
                        test(page: 1, name: widget.name, id: widget.id),
                  ));
                });
              },
              child: Text("تعديل بيانات امتحان"),
              style: ElevatedButton.styleFrom(
                  primary: Color.fromARGB(251, 86, 107, 224),
                  fixedSize: Size(180, 40),
                  shape: ContinuousRectangleBorder(
                      borderRadius: BorderRadius.circular(150))),
            )),
            SizedBox(
              height: 25,
            ),
            Container(
                child: ElevatedButton(
              onPressed: () {
                setState(() {
                  Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) =>
                        test(page: 2, name: widget.name, id: widget.id),
                  ));
                });
              },
              child: Text("حذف امتحان"),
              style: ElevatedButton.styleFrom(
                  primary: Color.fromARGB(251, 86, 107, 224),
                  fixedSize: Size(180, 40),
                  shape: ContinuousRectangleBorder(
                      borderRadius: BorderRadius.circular(150))),
            )),
            SizedBox(
              height: 200,
            ),
          ])))),
    );
  }
}
