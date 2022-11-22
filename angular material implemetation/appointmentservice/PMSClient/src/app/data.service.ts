import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DayPilot } from 'daypilot-pro-angular';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  resources: any[]=[
    {name:"Resource1",id:"R1"},
    {name:"Resource2",id:"R2"},
    {name:"Resource3",id:"R3"},
    {name:"Resource4",id:"R4"},
    {name:"Resource5",id:"R5"},
    {name:"Resource6",id:"R6"},
    {name:"Resource7",id:"R7"},
    {name:"Resource8",id:"R8"},
    {name:"Resource9",id:"R9"},
  ]

  
  events: any[] =[
  {
    id : 1,
    start:DayPilot.Date.today().addHours(10),
    text:"Event 1",
    phases:[
      {start:"2022-08-22",end:"2022-10-22",toolTip:"Preparation",background:"#b6d7a8"},
      {start:"2022-09-22",end:"2022-12-22",toolTip:"main phase",background:"#93c47d"},
      {start:"2022-10-22",end:"2022-11-22",toolTip:"evaluation",background:"#6aa84f"},
    ]
  }
];

getResources():Observable<any[]>
{
  return new Observable(observer =>{
    setTimeout(() =>{
      observer.next(this.resources);
    }, 200);
  })
}

  constructor(private http : HttpClient) 
  { 
  }
  
  getEvents(from:DayPilot.Date, to:DayPilot.Date) : Observable<any[]>{

    return new Observable(Observer =>{
      setTimeout(() => {
        Observer.next(this.events);
      }, 200)
    });
  }
}
