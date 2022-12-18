import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  writeFeedBack: boolean = false;
  constructor(private router:Router,
              public authService:AuthService) { }

  showWriteFeedBack(showElement: boolean) {
    this.writeFeedBack = showElement;
  }

  ngOnInit(): void {
  }

}
