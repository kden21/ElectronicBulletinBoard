import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup} from "@angular/forms";
import {Router} from "@angular/router";
import {AuthService} from "../../services/auth.service";

@Component({
  selector: 'app-headerhome',
  templateUrl: './headerhome.component.html',
  styleUrls: ['./headerhome.component.css']
})
export class HeaderhomeComponent implements OnInit {
  form = new FormGroup({
    description: new FormControl<string>(""),
  })
  constructor(private router: Router,
              public authService:AuthService) { }

  ngOnInit(): void {
  }

  submit(){
    let desc=this.form.value['description'] as string
    if(desc.toString().length!=0) {
      this.router.navigate(
        ['/'],
        {queryParams: {
          'search': desc
          }}
      );
    }
  }
}
