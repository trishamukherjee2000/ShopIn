import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { OnInit } from '@angular/core';
import { MainserviceService } from '../mainservice.service';
import { Product } from './Product';


@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.css']
})
export class MainpageComponent implements OnInit{
  data : Product[]=[];
  errorMessage : string="";
  islogin : boolean=false;
  constructor(private router: Router,private mainService: MainserviceService){}

  AddtoCart():void{
    this.router.navigate(['/bag']);
  }
  BuyNow():void{
    this.router.navigate(['/bag']);
  }

  getProducts() {
    console.log("OK")
    this.mainService.getProducts().subscribe({
       next:  products => this.data = products,
       error:error => this.errorMessage = <any>error
     })
   }
   ngOnInit() {
     this.getProducts();
   }
}
