import { Component } from '@angular/core';
import { User } from './models/user';
import { UserService } from './services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  
  user: User | null = null;
  


  constructor(private userService: UserService) {}
  onSubmit(event: any){
    this.userService.addUser(event).subscribe(res => {
      this.user = res;
    })
    
  }

  reset(){
    this.user = null;
  }
}
