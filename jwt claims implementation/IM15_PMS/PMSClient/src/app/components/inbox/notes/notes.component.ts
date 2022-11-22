import { Component, OnInit } from '@angular/core';
import { TitleSettings } from '@syncfusion/ej2/maps';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  isSendNote: boolean = true;
  isReceivedNote: boolean = false;
  isViewNote: boolean = false;

  displayNotes(id) {
    if (id == "send") {
      this.isSendNote = true;
      this.isReceivedNote = false;
      this.isViewNote = false;
    }
    else if (id == "received") {
      this.isSendNote = false;
      this.isReceivedNote = true;
      this.isViewNote = false;
    }
    else if (id == "view") {
      this.isSendNote = false;
      this.isReceivedNote = false;
      this.isViewNote = true;
    }
  }

}
