import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SpaceObjectComponent } from './spaceObject.component';

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [SpaceObjectComponent],
    bootstrap: [SpaceObjectComponent]
})
export class SpaceObjectModule { }