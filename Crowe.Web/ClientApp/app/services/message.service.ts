import { Injectable } from "@angular/core";
import { Http } from "@angular/http"
import { Observable } from "rxjs/Observable";
import { environment } from "../environment";

@Injectable()
export class MessageService {

    private Api_Url: string = environment.Api_Url;

    constructor(private http: Http) { }

    public loadMessage() {
        const url = `${this.Api_Url}/message`;
        return this.http.get(url);
    }
}