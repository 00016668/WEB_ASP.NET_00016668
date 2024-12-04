import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { GroupService } from '../../group.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create-group',
  templateUrl: './create-group.component.html',
  styleUrls: ['./create-group.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class CreateGroupComponent {
  groupForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private groupService: GroupService,
    private router: Router
  ) {
    this.groupForm = this.fb.group({
      groupName: ['', [Validators.required, Validators.minLength(3)]]
    });
  }

  onSubmit() {
    if (this.groupForm.valid) {
      this.groupService.createGroup(this.groupForm.value).subscribe({
        next: () => {
          alert('Group created successfully!');
          this.router.navigateByUrl('/home');
        },
        error: (err) => {
          console.error('Error creating group:', err);
          alert('Failed to create group.');
        }
      });
    }
  }

  onCancel() {
    this.router.navigateByUrl('/home');
  }
}
