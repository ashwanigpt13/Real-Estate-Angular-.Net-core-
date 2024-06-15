import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit{
  loggedInUser!:string|null;

constructor(private alertify: AlertifyService,private router:Router){}
ngOnInit(): void {
  console.log(localStorage.getItem('token') !== null)
  console.log(this.loggedIn())
}

loggedIn():string|null{
  // console.log(localStorage.getItem('token') != null ?true:false);
  this.loggedInUser = localStorage.getItem('userName') 
  //!= null ?true:false;
  console.log()
  return this.loggedInUser;
}
OnLogOut(){
  localStorage.removeItem('token');
  localStorage.removeItem('userName');

  console.log(localStorage.getItem('token'));
  this.alertify.success("Logged Out!")
  this.router.navigate(['/user/login'])
}
}
