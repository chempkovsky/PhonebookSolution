# PhonebookSolution
- Current repo is a complementary set of subproject for [AngularPhonebook](https://github.com/chempkovsky/AngularPhonebook) project.
- Current repo is an implementation of the Backend part of the solution
- [AngularPhonebook](https://github.com/chempkovsky/AngularPhonebook) is a Frontend of the solution.
  - Please open [AngularPhonebook](https://github.com/chempkovsky/AngularPhonebook) for readme.
- You can find detailed step-by-step instructions for creating code in the [CS82ANGULAR](https://github.com/chempkovsky/CS82ANGULAR/wiki) project's wiki.

### Xamarin app added to the current solution
- open solution in visual studio 2022
- make sure you corretly define
  - [appsettings.json of PhBkWebApp](https://github.com/chempkovsky/PhonebookSolution/blob/master/PhBkWebApp/appsettings.json)
  - [appsettings.json of LpPhBkWebApp](https://github.com/chempkovsky/PhonebookSolution/blob/master/LpPhBkWebApp/appsettings.json)
  - you do not need to setup RabbitMq 
- start the solution (press F5)
  - PhBkWebApp will be lanched (/LpdDivisionViewWebApi/getall)
  - LpPhBkWebApp will be be lanched
  - PrismPhonebook.UWP will be launched
  
- In the first swagger window run **/LpdDivisionViewWebApi/getall** one time (it will create databases and populate tables with data)
- In the second swagger window run **/PhbkDivisionViewWebApi/getall** one time (it will create databases and populate tables with data)
- After that PrismPhonebook.UWP will be ready to show data
  - don't add/remove/update data until RabbitMq settings are set
