import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../contact.service';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css'],
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule]
})
export class DeleteComponent {
  contactId: number = 0;
  contactName: string = '';

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.contactId = Number(this.route.snapshot.paramMap.get('id'));

    // Fetch the contact details to show the user what they are deleting
    this.contactService.getContactById(this.contactId).subscribe({
      next: (contact) => {
        this.contactName = `${contact.firstName} ${contact.lastName}`;
      },
      error: (err) => {
        console.error('Error fetching contact details:', err);
        alert('Contact not found!');
        this.router.navigate(['/home']); // Redirect if contact not found
      },
    });
  }

  onDelete(): void {
    this.contactService.deleteContact(this.contactId).subscribe({
      next: () => {
        alert('Contact deleted successfully!');
        this.router.navigate(['/home']);
      },
      error: (err) => {
        console.error('Error deleting contact:', err);
        alert('Failed to delete the contact.');
      },
    });
  }

  onCancel(): void {
    this.router.navigate(['/home']);
  }
}
