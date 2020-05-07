import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConstantService {
  API_ENDPOINT :String;
  CONSUMER_KEY : String;

  constructor() { 
    this.API_ENDPOINT = 'https://c685e4a8.ngrok.io/eduquayapi/api/v1/';
    this.CONSUMER_KEY = 'someReallyStupidTextWhichWeHumansCantRead'
  }
}
