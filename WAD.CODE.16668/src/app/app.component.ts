import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { HomeComponent } from './components/home/home.component';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatButtonModule, HomeComponent, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Contact Manager App';

  contacts = [
    {
      id: 1,
      firstName: "Axmadov",
      lastName: "Dilshod",
      phoneNumber: "123-456-7890",
      email: "axmadovd@example.com",
      dateOfBirth: "1990-05-14",
      groupId: 1
    },
    {
      id: 2,
      firstName: "Anvar",
      lastName: "Rajabboyev",
      phoneNumber: "987-654-3210",
      email: "a.rajabboyev@example.com",
      dateOfBirth: "1985-11-23",
      groupId: 2
    },
    {
      id: 3,
      firstName: "Akbar",
      lastName: "Abdurazzakov",
      phoneNumber: "456-789-0123",
      email: "akbar.abdu@example.com",
      dateOfBirth: "1995-07-08",
      groupId: 3
    }
  ];
}
