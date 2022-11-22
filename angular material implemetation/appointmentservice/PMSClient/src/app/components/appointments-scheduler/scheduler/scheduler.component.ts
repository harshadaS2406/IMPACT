import { AfterViewInit, Component,ViewChild } from '@angular/core';
import { DayPilot, DayPilotSchedulerComponent } from 'daypilot-pro-angular';
import { DataService } from 'src/app/data.service';

@Component({
  selector: 'app-scheduler',
  templateUrl: './scheduler.component.html',
  styleUrls: ['./scheduler.component.css']
})
export class SchedulerComponent implements AfterViewInit {
  @ViewChild("scheduler")
  scheduler: DayPilotSchedulerComponent = new DayPilotSchedulerComponent;
  events :DayPilot.EventData[]=[];
  config:DayPilot.SchedulerConfig = {
    timeHeaders : [
      {groupBy:"Month",format:"MMMM yyyy"},
      {groupBy:"Day",format:"d"},
    ],
    scale:"Day",
    days:30,
    startDate:"2021-06-01",
    onBeforeEventRender: args =>{
      if(args.data['phases'])
      {
        args.data.barHidden = true;
        args.data.html = '';
        args.data.toolTip = '';
        if(!args.data.areas)
        {
          args.data.areas = [];
        }
        args.data['phases'].forEach((phase: { start: any; end: any; text: any; toolTip: any; }) => {
          args.data.areas?.push({
            start:phase.start,
            end: phase.end,
            top :0,
            bottom: 0,
            //css: phase.css,
            style:"overflow:hidden;padding:3px;box-sizing:border-box;",
            background: phase.text,
            toolTip : phase.toolTip
          });
          
        });
      }
    },
    
    onEventMove: args =>{
      let offset = new DayPilot.Duration(args.e.start(),args.newStart);
      args.e.data.phases.forEach((phase: { start: string | DayPilot.Date | undefined; end: string | DayPilot.Date | undefined; }) =>
      {
        phase.start = new DayPilot.Date(phase.start).addTime(offset);
        phase.end = new DayPilot.Date(phase.end).addTime(offset);

      });
    }

  }

  constructor(private ds : DataService) { }
  ngAfterViewInit(): void {
    this.ds.getResources().subscribe(res => this.config.resources = res);
    var from = this.scheduler.control.visibleStart();
    var to = this.scheduler.control.visibleEnd();
    this.ds.getEvents(from,to).subscribe(res=>{
      this.events=res;
    });

  }

  ngOnInit(): void {
  }

}
