import { Component, OnInit } from '@angular/core';
import { MessageService } from '../../services/message.service';
import { Body } from '@angular/http/src/body';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    public message: any;

    constructor (private messageSvc: MessageService) { }

    ngOnInit(): void {
        this.messageSvc.loadMessage().subscribe(
            resp => {
                const x: any = resp;
                this.message = x._body;
            }
        );
    }
}
