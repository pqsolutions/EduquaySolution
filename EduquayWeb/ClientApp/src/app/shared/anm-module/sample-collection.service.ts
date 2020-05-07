import { Injectable } from '@angular/core';
import { ConstantService } from '../constant.service';
import { HttpClient } from '@angular/common/http';
import { SampleCollectionResponse } from './sample-collection-response';


@Injectable({
  providedIn: 'root'
})
export class SampleCollectionService {

  sampleCollectionApi: string = "SampleCollection/Retrieve";
  constructor(private constantService: ConstantService, private httpClient: HttpClient) { }

  getSampleCollection(){
    return this.httpClient.get<SampleCollectionResponse>(this.sampleCollectionApi);
  }

}
