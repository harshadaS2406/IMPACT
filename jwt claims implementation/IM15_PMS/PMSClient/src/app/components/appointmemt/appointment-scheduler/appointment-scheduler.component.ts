import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { DayPilot, DayPilotCalendarComponent, DayPilotKanbanComponent, DayPilotMonthComponent, DayPilotNavigatorComponent } from 'daypilot-pro-angular';
import { DataService } from 'src/app/data.service';

@Component({
  selector: 'app-appointment-scheduler',
  templateUrl: './appointment-scheduler.component.html',
  styleUrls: ['./appointment-scheduler.component.css']
})
export class AppointmentSchedulerComponent implements AfterViewInit {
  @ViewChild("day") day!:DayPilotCalendarComponent;
  @ViewChild("week") week!:DayPilotCalendarComponent;
  @ViewChild("month") month!:DayPilotMonthComponent;
  @ViewChild("navigator") nav!:DayPilotNavigatorComponent;


  events: DayPilotCalendarComponent[] = [];
  date = DayPilot.Date.today();
  configNavigator : DayPilot.NavigatorConfig ={
    showMonths: 3,
    cellWidth : 25,
    cellHeight: 25,
    onVisibleRangeChange:args =>{

      this.loadEvents();
    }


  };
  selectTomorrow()
  {
    this.date = DayPilot.Date.today().addDays(1);

  }

  changeDate(date:DayPilot.Date):void{
    this.configDay.startDate = date;
    this.configWeek.startDate = date;
    this.configMonth.startDate = date;
  }
  configDay : DayPilot.CalendarConfig = {
  };
 
  configWeek : DayPilot.CalendarConfig =
  {
    viewType : "Week",
    onTimeRangeSelect : async(args) =>{
      const modal = await DayPilot.Modal.prompt("Create a new event:","Event 1");
      const dp = args.control;
      dp.clearSelection();
      if(!modal.result){return;}
      dp.events.add(new DayPilot.Event({
        start: args.start,
        end: args.end,
        id: DayPilot.guid(),
        text:modal.result
      }));
    }
  };

  configMonth : DayPilot.MonthConfig = {};



  constructor(private ds : DataService) 
  {
    this.viewWeek();
  }
  ngAfterViewInit(): void {
    this.loadEvents();
     
  }
  loadEvents():void
  {
    const from =  this.nav.control.visibleStart();
    const to =  this.nav.control.visibleEnd();
    this.ds.getEvents(from ,to).subscribe(result =>{
      this.events = result;
    });
  }
  viewDay():void{
    this.configNavigator.selectMode = "Day";
    this.configDay.visible = true;
    this.configWeek.visible = false;
    this.configMonth.visible = false;
  }

  viewWeek():void{
    this.configNavigator.selectMode = "Week";
    this.configDay.visible = false;
    this.configWeek.visible = true;
    this.configMonth.visible = false;
  }

  viewMonth():void{
    this.configNavigator.selectMode = "Month";
    this.configDay.visible = false;
    this.configWeek.visible = false;
    this.configMonth.visible = true;
  }




  ngOnInit(): void 
  {

  }

}
