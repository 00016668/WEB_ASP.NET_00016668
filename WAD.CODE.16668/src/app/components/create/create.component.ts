import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ContactService } from '../../contact.service';
import { GroupService } from '../../group.service';
import { Group } from '../../Group';
import { Contact } from '../../Contact';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-create-contact',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class CreateComponent {
  contactForm: FormGroup;
  groups: Group[] = []; // Array to hold groups for dropdown

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService,
    private groupService: GroupService,
    private router: Router
  ) {
    this.contactForm = this.fb.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required]], 
      dateOfBirth: ['', [Validators.required]], 
      groupId: ['', [Validators.required]] 
    });
  }

  ngOnInit() {
    // Fetch all groups for dropdown
    this.groupService.getAll().subscribe(groups => {
      this.groups = groups;
    });
  }

  onSubmit() {
    if (this.contactForm.valid) {
      const contactData: Contact = {
        id: 0,
        firstName: this.contactForm.value.firstName,
        lastName: this.contactForm.value.lastName,
        email: this.contactForm.value.email,
        phoneNumber: this.contactForm.value.phoneNumber,
        dateOfBirth: this.contactForm.value.dateOfBirth,
        groupId: this.contactForm.value.groupId,
      };

      this.contactService.create(contactData).subscribe({
        next: () => {
          alert('Contact created successfully!');
          this.router.navigateByUrl('/home');
        },
        error: (err) => {
          console.error('Error creating contact:', err);
          console.error('Full error object:', JSON.stringify(err, null, 2));
          if (err.error) {
            console.error('Error details:', err.error);
          } else {
            console.error('No error details available.');
          }
          alert('Failed to create contact.');
        }
      });
    }
  }

  onCancel() {
    this.router.navigateByUrl('/home');
  }
}
