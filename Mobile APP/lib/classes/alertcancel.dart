import 'package:flutter/material.dart'; 

class alertcancel extends StatefulWidget {
  const alertcancel({super.key});

  @override
  State<alertcancel> createState() => _alertcancelState();
}

class _alertcancelState extends State<alertcancel> {
 
  @override
  Widget build(BuildContext context) {
    return TextButton(
    child: Text("Cancel"),
    onPressed: () { Navigator.of(context).pop();},
  );
  }
}