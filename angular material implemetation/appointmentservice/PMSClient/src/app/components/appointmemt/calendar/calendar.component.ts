import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { DayPilot, DayPilotCalendarComponent, DayPilotMonthComponent, DayPilotNavigatorComponent } from 'daypilot-pro-angular';
import { Appointment } from 'src/app/models/Appointment';
import { AppointmentService } from 'src/app/services/appointment.service';

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
  appointmentList: any;
  appointmentLists: Appointment[]=[];
  events:DayPilot.EventData[]=[];

 
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
  


  constructor(private router : Router,private appointmentService: AppointmentService) { }

  
  
    
    userid:number;
    roleid:number;



  ngOnInit(): void {
    
    //this.getAppointments();   
    
    const useid = localStorage.getItem("userid");
     if (typeof useid === 'string')
      {
      this.userid = Number(JSON.parse(useid))
      }
     const rolid = localStorage.getItem("roleid");
     if (typeof rolid === 'string')
      {
      this.roleid = Number(JSON.parse(rolid))
      }

      this.getAppointmentsByRole();
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


  today(): void {
    this.config.startDate = DayPilot.Date.today();
    this.config.days = this.config.startDate.daysInMonth();
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



  configWeek: DayPilot.CalendarConfig = {
    viewType: "Week",
    onTimeRangeSelected: async (args) => {
      const modal = await DayPilot.Modal.prompt("Create a new event:", "Event 1");
      const dp = args.control;
      dp.clearSelection();
      if (!modal.result) { return; }
      dp.events.add(new DayPilot.Event({
        start: args.start,
        end: args.end,
        id: DayPilot.guid(),
        text: modal.result
      }));
    }
  };

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

  getAppointments(){
    this.appointmentService.getAppointments().subscribe((data:any)=>{
    this.appointmentList = data;
    this.appointmentLists =this.appointmentList;
    console.log(this.appointmentLists);
    console.log(this.appointmentLists[0].visitDescription);

    })

  }

  getAppointmentsByRole(){
    this.appointmentService.getAppointmentsByRoleId(4,3).subscribe((data:any)=>{
    console.log(data);
    this.events = data;

    })

  }

}

