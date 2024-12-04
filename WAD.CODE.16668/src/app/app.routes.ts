import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CreateGroupComponent } from './components/create/create-group.component';
import { CreateComponent } from './components/create/create.component'; 
import { EditComponent } from './components/edit/edit.component';
import { DetailsComponent } from './components/details/details.component';
import { DeleteComponent } from './components/delete/delete.component';

export const routes: Routes = [
    {
        path: "",
        component: HomeComponent
    },
    {
        path: "home",
        component: HomeComponent
    },
    {
        path: "create-group", 
        component: CreateGroupComponent
    },
    {
        path: "create", 
        component: CreateComponent 
    },
    {
        path: "edit/:id",
        component: EditComponent
    },
    {
        path: "details/:id",
        component: DetailsComponent
    },
    {
        path: "delete/:id",
        component: DeleteComponent
    },
    {
        path: '', 
        redirectTo: '/home', 
        pathMatch: 'full'
    }
];
