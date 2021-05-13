import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledRecepataComponent } from './pregled-recepata.component';

describe('PregledRecepataComponent', () => {
  let component: PregledRecepataComponent;
  let fixture: ComponentFixture<PregledRecepataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledRecepataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledRecepataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
