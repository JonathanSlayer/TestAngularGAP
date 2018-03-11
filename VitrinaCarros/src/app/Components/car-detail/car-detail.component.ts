import { Component, OnInit,Input } from '@angular/core';
import { CarDetail } from '../../Models/cars.model';
@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.scss']
})
export class CarDetailComponent implements OnInit {
  @Input() detail: any;
  constructor() { }

  ngOnInit() {
  }

}
