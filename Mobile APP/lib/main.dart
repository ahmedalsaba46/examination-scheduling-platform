import 'package:flutter/material.dart';
import 'package:organizing_dates_examinations/test.dart';
import 'package:organizing_dates_examinations/home.dart';
import 'package:organizing_dates_examinations/test/addtest.dart';
import 'login.dart';
import 'package:flutter_localizations/flutter_localizations.dart';

void main() {
  runApp(Organizing_dates_examinations());
}

class Organizing_dates_examinations extends StatefulWidget {
  const Organizing_dates_examinations({super.key});

  @override
  State<Organizing_dates_examinations> createState() =>
      _Organizing_dates_examinationsState();
}

class _Organizing_dates_examinationsState
    extends State<Organizing_dates_examinations> {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      localizationsDelegates: [
        GlobalMaterialLocalizations.delegate,
        GlobalWidgetsLocalizations.delegate,
        GlobalCupertinoLocalizations.delegate,
      ],
      supportedLocales: [
        Locale('ar', 'AE'),
      ],
      home: login(),
      // home(name: "ahmed alsaba", id: "1")
    );
  }
}
