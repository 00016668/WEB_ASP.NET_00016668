import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Contact } from '../../Contact';
import { ContactService } from '../../contact.service';
import { GroupService } from '../../group.service';  // Import GroupService to fetch group details
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class DetailsComponent implements OnInit {
  contact: Contact | null = null;
  error: string | null = null;

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService,
    private groupService: GroupService // Inject GroupService to fetch group details
  ) {}

  ngOnInit(): void {
    const contactId = Number(this.route.snapshot.paramMap.get('id'));
    if (!isNaN(contactId)) {
      this.getContactDetails(contactId);
    } else {
      this.error = 'Invalid Contact ID';
    }
  }

  getContactDetails(id: number): void {
    this.contactService.getContactById(id).subscribe({
      next: (contact) => {
        this.contact = contact;
        // Fetch the group details by groupId if it exists
        if (this.contact.groupId) {
          this.groupService.getById(this.contact.groupId).subscribe({
            next: (group) => {
              if (this.contact) {
                this.contact.group = group;  // Attach the group to the contact
              }
              this.error = null;
            },
            error: (err) => {
              console.error('Error fetching group details:', err);
              if (this.contact) {
                this.contact.group = undefined;  // Set to undefined instead of null
              }
            }
          });
        } else {
          // If no groupId, set group to undefined
          if (this.contact) {
            this.contact.group = undefined;
          }
        }
        this.error = null;
      },
      error: (err) => {
        console.error('Error fetching contact details:', err);
        this.error = 'Failed to load contact details.';
      },
    });
  }
}
  
