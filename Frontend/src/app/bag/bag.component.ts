import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bag',
  templateUrl: './bag.component.html',
  styleUrls: ['./bag.component.css']
})
export class BagComponent {
  constructor(private router: Router){}
  ngOnInit(): void {
    
  }
  GoToPage()
  {
    this.router.navigate(['/payment']);
  }
}
