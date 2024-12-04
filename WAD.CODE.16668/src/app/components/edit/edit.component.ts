import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../contact.service';
import { GroupService } from '../../group.service';
import { Contact } from '../../Contact';
import { Group } from '../../Group';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class EditComponent implements OnInit {
  contactForm: FormGroup;
  groups: Group[] = [];
  contactId!: number;
  isLoading: boolean = true;  

  constructor(
    private fb: FormBuilder,
    private contactService: ContactService,
    private groupService: GroupService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.contactForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      dateOfBirth: ['', [Validators.required]],
      groupId: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    this.contactId = Number(this.route.snapshot.paramMap.get('id'));

    // Fetch groups for the dropdown
    this.groupService.getGroups().subscribe({
      next: (groups) => {
        this.groups = groups;
        this.isLoading = false;  
      },
      error: (err: unknown) => {
        console.error('Error fetching groups:', err);
        this.isLoading = false;  
      }
    });

    
    this.contactService.getContactById(this.contactId).subscribe({
      next: (contact: Contact) => {
        this.contactForm.patchValue({
          firstName: contact.firstName,
          lastName: contact.lastName,
          phoneNumber: contact.phoneNumber,
          email: contact.email,
          dateOfBirth: contact.dateOfBirth ? contact.dateOfBirth.toString().split('T')[0] : '',
          groupId: contact.groupId
        });
      },
      error: (err: unknown) => console.error('Error fetching contact details:', err)
    });
  }

  onSubmit(): void {
    if (this.contactForm.valid) {
      const updatedContact: Contact = {
        id: this.contactId,
        ...this.contactForm.value,
        group: undefined, 
        dateOfBirth: new Date(this.contactForm.value.dateOfBirth).toISOString()
      };

      this.contactService.updateContact(this.contactId, updatedContact).subscribe({
        next: () => {
          alert('Contact updated successfully!');
          this.router.navigateByUrl('/'); 
        },
        error: (err: HttpErrorResponse) => {
          console.error('Error updating contact:', err);
          alert(`Failed to update contact: ${err.message}`);
        }
      });
    }
  }

  onCancel(): void {
    this.router.navigateByUrl('/'); 
  }
}
