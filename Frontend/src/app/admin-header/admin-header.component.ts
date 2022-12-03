import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.css']
})
export class AdminHeaderComponent {
  constructor(private route:Router){}
  ProfileRouting():void{
    this.route.navigate(['/myprofile'])
  }
}
