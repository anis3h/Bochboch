import { Component } from '@angular/core';
import { Rectangle } from '../Shared/rectangle';
import { RectangleService } from '../services/rectangle/rectangle.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  colors: string[] = ["grey", "red", "orange", "magenta", "blue", "yellow", "green", "black"];

  public rectangles: Rectangle[];
  constructor(private rectangleService: RectangleService) {
    this.getRectangle();
  }
  public colorChange(event: Event, rectangle: Rectangle) {
    var index = this.colors.findIndex(row => row === rectangle.color);
    console.log(rectangle.id);
    this.rectangles.find(row => row.id === rectangle.id).color = this.colors[++index];
  }

  getRectangle() {
    this.rectangleService.getFamilyPatient().subscribe(async result => {
      this.rectangles = result;
    },
      error => console.error(error)
    );

  }

  saveColors() {
    console.log("Test");
    this.rectangleService.updateFamilyPatient(this.rectangles).subscribe(() => {
      console.log("rectangle saved");
      this.goBack();
    });
  }

  goBack(): void {
    // navigates backward one step in the browser's history stack using the Location service
    //this.location.back();
  }

}
