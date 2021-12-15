# Overview
The purpose of this document is to lay out the different Functional and Non-Functional Requirements of the term project. This will aid in nailing down the key requirements of the end product as well as important characteristics that must be considered during development and planning.

# Software Requirements
This document will lay out the functional and non-functional requirements of the software.

## Functional Requirements

### Car Paint Options - Configuration Scene
| ID | Requirement |
| :-------------: | :----------: |
| FR1 | The car's color shall change to the selected option when a paint option button is clicked. |
| FR2 | The car's price shall change accordingly when a paint option button is clicked. |
| FR3 | The "glossy" slider below the paint buttons shall adjust the glossiness of the car's paint. |
| FR4 | The "glossy" slider and its value shall not change when a different paint option button is clicked. |
| FR5 | The most recently selected paint option button will be dimly highlighted to show it is currently selected. |

### Seat Material / Rims Finish Options - Configuration Scene
| ID | Requirement |
| :-------------: | :----------: |
| FR6 | The car's seat material shall change to the selected option when a seat material button is clicked. |
| FR7 | The car's rim finish shall changed to the selected option when a rim finish button is clicked. |
| FR8 | The car's price shall changed accordignly when a seat material button is clicked. |
| FR9 | The car's price shall changed accordignly when a rim finish button is clicked. |
| FR10 | The most recently selected seat material button will be dimly highlighted to show it is currently selected. |
| FR11 | The most recently selected rims finish button will be dimly highlighted to show it is currently selected. |

### Mock Checkout Feature - Configuration Scene
| ID | Requirement |
| :-------------: | :----------: |
| FR12 | The Checkout popup shall appear when the user clicks on the "Checkout" button. |
| FR13 | The Checkout popup shall display a summary of the currently selected options, dynamically, that is: adjusting to any changes. |
| FR14 | The Checkout popup shall display a total price calculation, dynamically, that is: adjusting to any changes. |
| FR15 | The Purchase Confirmation popup shall appear when the user clicks on the "Purchase" button within the Checkout popup. |
| FR16 | The Checkout popup shall disappear when the user clicks on the red "X" on the popup. |
| FR17 | The Purchase Confirmation popup shall disappear when the user clicks on the "Confirm" button. |

### Car Data Persistence
| ID | Requirement |
| :-------------: | :----------: |
| FR18 | The Car's data shall be stored in a dedicated CarDataManager instance. |
| FR19 | The CarDataManager instance shall store the paint options, glossy value, seat material, and rims finish options. |
| FR20 | The CarDataManager instance shall not be destroyed on scene change (Singleton). |
| FR21 | The options stored in the CarDataManager shall be applied on the Car whenever a scene is changed to ensure that it looks visually correct. |
| FR22 | The Checkout popup shall disappear when the user clicks on the red "X" on the popup. |
| FR23 | The Purchase Confirmation popup shall disappear when the user clicks on the "Confirm" button. |

### Test Drive Scene
| ID | Requirement |
| :-------------: | :----------: |
| FR24 | The Car shall be configured as it was in the Configuration scene. |
| FR25 | The Car shall be driveable using the W/A/S/D controls. |
| FR26 | The Car shall be driveable along a linear race track that consists of a road and landscape (grass, trees). |
| FR27 | The Car shall emit different kinds of audio for when it is idle and when it is accelerating. |
| FR28 | The Camera following the Car can be placed in an alternate angle by pressing the "Left Alt" key. |
| FR29 | The User shall be able to return to the Configuration Scene by pressing the "Esc" key. |

## Non-Functional Requirements

### Operational Requirements
| ID | Requirement |
| :-------------: | :----------: |
| NFR1 | The Configurator shall perform its features without crashing with a 95% reliability. |
| NFR2 | The Configurator shall be built and deployed either as an separate executable. |
| NFR3 | The Configurator shall be launchable on any PC using the Windows OS that is compatible with the x86_64 architecture. |
| NFR4 | The controls for the Configurator shall be accessible via keyboard and mouse. |
| NFR5 | The Configurator's audio shall be playable on a speaker regarldess of its configuration (mono/stereo). |
| NFR6 | The Configurator's shall not require an Internet connection to be launched. |

### Performance Requirements
| ID | Requirement |
| :-------------: | :----------: |
| NFR7 | The Configurator shall run at a minimum of 60 FPS (or whatever the screen's refresh rate is set at). |
| NFR8 | The Option buttons (paint, seat, rims) shall apply its changes within 2 seconds of being pressed. |
| NFR9 | The Glossy Slider shall apply its changes within 2 seconds being changed. |
| NFR10 | The Configurator shall transition between its scenes (Configuration/Test Drive) within 2 seconds of being changed. |
| NFR11 | In the Test Drive Scene, the car shall move when the drive keys are pressed with minimal delay. |
| NFR12 | The audio of the Configurator shall be played at a minimum bitrate of 128kbps. |

### Security Requirements
| ID | Requirement |
| :-------------: | :----------: |
| NFR13 | The Configurator shall not access any data within the PC. |
| NFR14 | The Configurator shall not collect any input data from user actions. |
| NFR15 | The Configurator shall not collect any biometric data from user actions. |
| NFR16 | The Configurator shall not collect any visual data from the user's webcam. |
| NFR17 | In the mock purchase popup, the Configurator shall not collect any payments from the user. |

### Localization Requirements
| ID | Requirement |
| :-------------: | :----------: |
| NFR18 | The Configurator's primary language shall be English (United States). |
| NFR19 | The Configurator's currency shall be US Dollars. |
| NFR20 | The Configurators built-in Unity Crash Handler shall serve the user in English (United States). |
| NFR21 | The Configurator shall be executable regardless of system's system locale, so long as it supports UNICODE. |
| NFR22 | If using a voice-assistant, the only available language for reading out the text shall be English. |

### Other Non-Functional Requirements
| ID | Requirement |
| :-------------: | :----------: |
| NFR23 | The Configurator shall only use assets that have been acquired legally. |
| NFR24 | The Configurator shall not use any trademarked vehicles or brands. |
| NFR25 | The Configurator shall not use any trademarked assets (graphics/audio). |
| NFR26 | The Configurator shall have UI that is easily understood and followable. |
| NFR27 | The Configurator shall not exit until it is specifically requested, either by closing the window or pressing the "Esc" button. |

# Change Management Plan
Although the basic concepts of the software should be pretty straightforward, a certain level of knowledge transfer should be expected.
For one, the intentions of the software should be clearly relayed. In no way is this software intended to actually sell or demonstrate an actual product for an actual company.
This software is intended to serve as a technical demo for a possible solution that could be developed. 
Certain websites could have configuration apps for their products that the user could spec out and choose to purchase and in this case the app would be built as a WebGL app.
But because this is a desktop .exe app, it would only be presented and shown in a limited, private setting with the purpose of generating discourse.
Because the basic controls and concepts of the app are simple, the more abstract controls (camera, driving) are displayed on a small Hud in the top-right corner.
It is inferred that the user would already understand that clicking on the different option buttons (paint, seat, rims) would apply those options on the car that is before them.
Additionally, because the file size of the app is considerably large (~82MB) and there are a lot of dependencies it needs to run within the "Car Configurator_Data" folder, it is recommended that it is shared as a compressed file. (.zip, .rar, .7z)
Because the current build is intended for computers running the Windows OS, that is an important consideration to be made when trying to run it on a demo machine.
If the app crashes, the in-built Unity Crash Handler is a good way to report it to the original developer. Or, you can always contact the developer directly with a detected issue.

# Traceability Links
These traceability links will show proof of how different artifacts like Use Case Diagrams, Class Diagrams, and Activity Diagrams can be connected to the requirements laid out in the Software Requirements section of this document.

## Use Case Diagram Traceability
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| UseCase1 | Move Player | FR5 |
| … | … | … |

## Class Diagram Traceability
| Artifact Name | Requirement ID |
| :-------------: |:----------: |
| classPlayer | NFR3, FR5 |
| … | … | … |

## Activity Diagram Traceability
| Artifact ID | Artifact Name | Requirement ID |
| :-------------: | :----------: | :----------: |
| <filename> | Handle Player Input | FR1-5, NFR2 |
| … | … | … |

# Software Artifacts