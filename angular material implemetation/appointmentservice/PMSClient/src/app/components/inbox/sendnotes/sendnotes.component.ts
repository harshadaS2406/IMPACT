import { Component, OnInit } from '@angular/core';
import { NotesService } from 'src/app/services/notes.service';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NotesModel } from 'src/app/models/notes';
import { NgToastService } from 'ng-angular-popup';
import { ResponseModel } from 'src/app/models/responseModel';

@Component({
  selector: 'app-sendnotes',
  templateUrl: './sendnotes.component.html',
  styleUrls: ['./sendnotes.component.css']
})
export class SendnotesComponent implements OnInit {

  isSubmitted: boolean = false;
  sendNoteForm!: FormGroup;
  users: any[];
  receiver: any;
  receiverDesignation = '';
  receiverId!: number;
  receiverName: string = '';
  noteobj!: NotesModel;
  loggedUserId: number;

  constructor(private _service: NotesService, private _formBuilder: FormBuilder, private _toast: NgToastService) { }

  ngOnInit(): void {
    this.loggedUserId = Number(localStorage.getItem('userid'));
    this.getUserList()

    this.sendNoteForm = this._formBuilder.group({
      receiverName: new FormControl('Select Receiver Name', Validators.required),
      receiverDesignation: new FormControl('', [Validators.required]),
      message: new FormControl('', [Validators.required]),
      urgency: new FormControl('true', [Validators.required])
    });

  }

  getUserList() {
    this._service.getUsers(this.loggedUserId).subscribe((response: any) => {
      this.users = response.dataSet;
      console.log(this.users);
    });
  }

  onOptionSelect(event) {
    this.receiver = this.users.find(x => x.userId == event.target.value);
    this.receiverDesignation = this.receiver.role;
    this.receiverId = this.receiver.userId;
    this.receiverName = this.receiver.name;
  }

  sendNote() {
    this.isSubmitted = true;
    if (this.sendNoteForm.valid) {
      debugger;
      this.noteobj = new NotesModel();
      this.noteobj.senderId = this.loggedUserId;
      //this.noteobj.senderName = "Mr Luke Walker";
      //this.noteobj.senderDesignation = "Doctor";
      this.noteobj.receiverId = this.receiverId;
      this.noteobj.receiveName = this.receiverName;
      this.noteobj.receiverDesignation = this.receiverDesignation;
      this.noteobj.message = this.sendNoteForm.get('message')?.value;//"Hi Bernie Send patient Details"//
      this.noteobj.replyId = null;
      this.noteobj.isResponded = false;
      this.noteobj.isUrgent = this.sendNoteForm.get('urgency')?.value == "true" ? true : false;
      this.noteobj.deleteFlag = false;
      console.log(this.noteobj);
      this._service.sendNotes(this.noteobj).subscribe((data: ResponseModel) => {
        if (data.responseCode == 1) {
          debugger;
          console.log(data);
          this._toast.success({ detail: "Sent Message", summary: "Successfully!", duration: 3000 });
          this.ngOnInit();

        }
        else {
          this._toast.error({ detail: "Error Message", summary: "Error Success!", duration: 3000 });
        }
      })
    }
  }

}
