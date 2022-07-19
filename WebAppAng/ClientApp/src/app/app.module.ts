import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { StarSystemComponent } from 'src/app/starSystems/starSystem.component';
import { SpaceObjectComponent } from 'src/app/spaceObjects/spaceObject.component';
import { AppComponent } from 'src/app/app.component';
import { Routes, RouterModule } from '@angular/router';

const appRoutes: Routes = [
    { path: '', component: StarSystemComponent },
    { path: 'spaceobjects', component: SpaceObjectComponent },
    { path: 'starsystems', component: StarSystemComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, StarSystemComponent, SpaceObjectComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }