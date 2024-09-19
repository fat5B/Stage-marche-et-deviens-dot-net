import { Component, OnInit } from '@angular/core';
import { CommonModule } from "@angular/common";
import { FormsModule, NgForm } from "@angular/forms";
import { NavbarComponent } from '../Components/navbar/navbar.component';

@Component({
  selector: 'app-page-devis',
  standalone: true,
  imports: [CommonModule, FormsModule, NavbarComponent],
  templateUrl: './page-devis.component.html',
  styleUrls: ['./page-devis.component.scss']
})
export class PageDevisComponent implements OnInit {
  constructor() {}

  isTypeGroupeOpenState = false;
  isTypeProjetOpenState = false;
  typeGroupeValue = '';
  typeProjetValue = '';

  openTypeGroupe() {
    this.isTypeGroupeOpenState = true;
  }

  closeTypeGroupe() {
    this.isTypeGroupeOpenState = false;
  }

  changeTypeGroupe(event: any) {
    this.typeGroupeValue = event.target.value;
  }

  openTypeProjet() {
    this.isTypeProjetOpenState = true;
  }

  closeTypeProjet() {
    this.isTypeProjetOpenState = false;
  }

  changeTypeProjet(event: any) {
    this.typeProjetValue = event.target.value;
  }

  ngOnInit() {
    console.log('Composant initialisé');
  }

  onSubmit(devisForm: NgForm) {
    if (devisForm.valid) {
      fetch('http://localhost:5001', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(devisForm.value)
      })
      .then(response => response.json())
      .then(data => {
        console.log('Email envoyé avec succès', data);
      })
      .catch(error => {
        console.error('Erreur lors de l\'envoi de l\'email', error);
      });
    }
  }
}
