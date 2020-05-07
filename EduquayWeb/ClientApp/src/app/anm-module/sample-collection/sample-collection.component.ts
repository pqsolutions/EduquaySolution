import { Component, OnInit } from '@angular/core';
import { SampleCollectionService } from 'src/app/shared/anm-module/sample-collection.service';
import { SampleCollectionResponse } from 'src/app/shared/anm-module/sample-collection-response';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-sample-collection',
  templateUrl: './sample-collection.component.html',
  styleUrls: ['./sample-collection.component.css']
})
export class SampleCollectionComponent implements OnInit {
  sollectionErrorMessage: string;
  sampleCollectionResponse: SampleCollectionResponse;
  constructor(private sampleCollectionService: SampleCollectionService) { }

  ngOnInit() {
    console.log(this.sampleCollectionService.sampleCollectionApi);
    this.anmSampleCollection();
  }

  anmSampleCollection(){
    let sampleCollection = this.sampleCollectionService.getSampleCollection()
    .subscribe(response => {
      this.sampleCollectionResponse = response;
      if(!this.sampleCollectionResponse && this.sampleCollectionResponse.status == "true"){

      }
      
    },
    (err: HttpErrorResponse) => {
      this.sollectionErrorMessage = err.toString();
    });
  }

}
