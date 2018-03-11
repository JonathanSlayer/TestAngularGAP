import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Car } from '../../Models/cars.model';
@Component({
  selector: 'app-car-thumbnail',
  templateUrl: './car-thumbnail.component.html',
  styleUrls: ['./car-thumbnail.component.scss']
})
export class CarThumbnailComponent implements OnInit {
  @Input() car: Car;
  @Input() hidecheck: boolean;  
  @Output() compareCars= new EventEmitter<string>();
  constructor() { }
  ngOnInit() {
  }  
  onCompareCars(car){
    this.compareCars.next(car);
  } 
}
