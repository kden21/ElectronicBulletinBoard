import {Component, OnInit} from '@angular/core';
import {IUser} from "../../models/user";
import {BehaviorSubject} from "rxjs";
import {ILoginResponse} from "../../models/loginResponse";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  public userId: number;
  resp:ILoginResponse
  user: IUser

  public isLogin$: BehaviorSubject<IUser|null> = new BehaviorSubject<IUser | null>(null);

  constructor(public authService: AuthService,
              private router: Router,) {
  }

  ngOnInit(): void {
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/');
  }

  inChat(){
    this.router.navigateByUrl(`/chat`)
  }
}
