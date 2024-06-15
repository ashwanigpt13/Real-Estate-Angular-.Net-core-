import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-landing-page-home',
  templateUrl: './landing-page-home.component.html',
  styleUrls: ['./landing-page-home.component.css']
})
export class LandingPageHomeComponent {
  constructor(private router: Router) {}

  navigateTo(route: string) {
    this.router.navigate([`/${route}`]);
  }
}
