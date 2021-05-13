import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PregledaLijekovaComponent } from './pregleda-lijekova.component';

describe('PregledaLijekovaComponent', () => {
  let component: PregledaLijekovaComponent;
  let fixture: ComponentFixture<PregledaLijekovaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PregledaLijekovaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PregledaLijekovaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
