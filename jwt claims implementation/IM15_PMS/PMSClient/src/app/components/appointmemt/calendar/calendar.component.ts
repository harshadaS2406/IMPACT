import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DayPilot, DayPilotCalendarComponent, DayPilotMonthComponent, DayPilotNavigatorComponent } from 'daypilot-pro-angular';
import { DataService } from 'src/app/data.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {
 
  showModal:boolean =false;
  enableMonth: boolean=false;
  enableWeek: boolean=true;
  enableDay: boolean=false;
 
  @ViewChild("navigator") nav!:DayPilotNavigatorComponent;
  @ViewChild("month") month!: DayPilotMonthComponent;
  @ViewChild("calendar")
  calendar !: DayPilotCalendarComponent;
  config : DayPilot.CalendarConfig = {
    startDate : DayPilot.Date.today(),
    viewType : "Week",
    heightSpec : "Fixed",
    height : 400,
    
    // theme : "calendar_white",
    onEventMoved: args => {
      console.log("Event moved");
    },
  //   onEventClick:arg=>{
  //    // alert(arg.e.id());
  //     //this.router.navigate(['/Appointment-creation' ,arg.e.id()]);
  //     // this.openModal();
  //     // var modal = new DayPilot.Modal()
  //     // modal.onShow = function(arg)

  //     // {
  //     //   clearSelection();
  //     //   var data = args.e.data;
  //     //   if(data && data.result ==="OK" )
  //     //   {
         
  //     //   }
  //     // }
  // //      this.showModal = true;
  // //      var dp = new DayPilot.Calendar("dp");
  // //     dp.contextMenu = new DayPilot.Menu({items: [
  // //   {text:"Delete", onClick: function(args) { var e = args.source; dp.events.remove(e); } },
  // //   {text:"Edit" , onClick:function(args){var e = args.source; dp.events.update(e)}}
  // // ]});
  // // // ...
  // // dp.init();
      
      
  //   },

    
   

  
    eventDeleteHandling: "Update",
    
    onEventDeleted: args => {
      alert("appointment is declined"+args.e.id());
      //this.appointmentService.declineAppointment(Number(args.e.id()));
      
       console.log(args.e.id());
    },   
    onEventClick:args=>{
      let id = Number(args.e.id());
      //this.router.navigate(['/dashboard/edit-appointment/'+id]);
    },
    onEventRightClick:args=>{
      let id = Number(args.e.id());
      alert("appointment accepted"+id);
    },
    
    

    eventClickHandling : "Edit",
    onEventEdit : arg =>{
      alert("Clicked"+arg.e.id());
      this.router.navigate(['/Appointment-creation' ,arg.e.id()]);
    }
    
    
    
    
  }
  events: DayPilot.EventData[]= [
    { id: 1, start: "2022-11-14T10:00:00", end: "2022-11-15T14:00:00", text: "Event 1" },
    { id: 2, start: "2022-11-16T10:00:00", end: "2022-11-17T14:00:00", text: "Event 2" }

  ]



  constructor(private router : Router,private ds : DataService) { }

  
  
    
    



  ngOnInit(): void {


    

    
  }

  configMonth: DayPilot.MonthConfig = {
    eventDeleteHandling: "Update",
    
    onEventDeleted: args => {
      
      //this.appointmentService.declineAppointment(Number(args.e.id()));
      
       console.log(args.e.id());
    },   
    onEventClick:args=>{
      let id = Number(args.e.id());
      //this.router.navigate(['/dashboard/edit-appointment/'+id]);
    },
    onEventRightClick:args=>{
      let id = Number(args.e.id());
      alert("appointment accepted"+id);
    },
  };


  navigatePrevious(event:any): void {
    event.preventDefault();
    if(this.enableMonth){
      
      this.configMonth.startDate = (this.config.startDate as DayPilot.Date).addMonths(-1);
    }
    else if(this.enableWeek)
    this.config.startDate = (this.config.startDate as DayPilot.Date).addDays(-7);
    else if(this.enableDay)
    this.config.startDate = (this.config.startDate as DayPilot.Date).addDays(-1);
    
  }


  
  navigateToday(event:any): void {
    event.preventDefault();
    if(this.enableMonth){
      
      this.configMonth.startDate = (this.config.startDate as DayPilot.Date);
    }
    else if(this.enableWeek)
    this.config.startDate = (this.config.startDate as DayPilot.Date);
    else if(this.enableDay)
    this.config.startDate = (this.config.startDate as DayPilot.Date);
    
    
  }

  navigateNext(event:any): void {
    event.preventDefault();
    if(this.enableMonth){
      
      this.configMonth.startDate = (this.config.startDate as DayPilot.Date).addMonths(1);
    }
    else if(this.enableWeek)
    this.config.startDate = (this.config.startDate as DayPilot.Date).addDays(7);
    else if(this.enableDay)
    this.config.startDate = (this.config.startDate as DayPilot.Date).addDays(1);
    
    
  }


  displayMonth(){
    this.enableMonth=true;
    this.enableWeek=false;
    this.enableDay=false;
    this.config.visible = false;
    this.configMonth.visible=true;
    
  }  
  displayWorkWeek(){
    this.enableMonth=false;
    this.enableDay=false;
    this.enableWeek=true;
    this.configMonth.visible=false;
    this.config.visible = true;
    this.config.viewType="WorkWeek";
  }
  
  displayDay(){
    this.enableMonth=false;
    this.enableWeek=false;
    this.enableDay=true;
    
    this.configMonth.visible=false;
    this.config.visible = true;    
    this.config.viewType="Day"
  }

}

