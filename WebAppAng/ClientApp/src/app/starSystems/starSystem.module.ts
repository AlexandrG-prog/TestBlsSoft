import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { StarSystemComponent } from './starSystem.component';
import { SpaceObjectComponent } from 'src/app/spaceObjects/spaceObject.component';

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [StarSystemComponent],
    bootstrap: [StarSystemComponent]
})
export class StarSystemModule { }