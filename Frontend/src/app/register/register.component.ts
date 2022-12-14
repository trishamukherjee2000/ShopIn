import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { MainserviceService } from '../mainservice.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  registered:Boolean =false;
  constructor(private router: Router,private mainService: MainserviceService){}
 
  submit(register:NgForm){
    console.log(register.value.uname, register.value.email, register.value.pwd,  register.value.phn, register.value.addrss );
    this.mainService.AddUsers(register.value.uname, register.value.email, register.value.pwd,  register.value.phn, register.value.addrss ).subscribe({
      next:  (status) => {
        this.registered = status;
        if(this.registered){
          alert("Registered SuccessFully");
          this.router.navigate(['/login']);
        }
        else
          alert("Error !!");
      },
      error: (error) => {
        this.registered = false;
        alert("Error !!");
      }
    })
    
  }

}