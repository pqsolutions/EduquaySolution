import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-site-sidebar',
  templateUrl: './site-sidebar.component.html',
  styleUrls: ['./site-sidebar.component.css']
})
export class SiteSidebarComponent implements OnInit {
  @Input() module: string;
  @Input() subMenum: string;

  constructor() { }

  ngOnInit() {
    
  }

}
