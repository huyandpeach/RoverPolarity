# Rover: Polarity - Report Notes

## Current decisions

- The current project scope is one playable level. Additional levels are a future development opportunity.
- The player must collect the required crystals to unlock the exit and complete the level. The final number is not yet confirmed here.
- Write the report in stages, beginning with Chapter 1.1.
- Return to the project proposal later to develop its reference list and reconcile it with the current scope.

## Proposal points to revisit

- The existing proposal describes four levels and collecting two crystals before the exit; check these against the final design.
- The proposal states Waterfall as the methodology. Describe the actual development process honestly, including prototype testing and revisions.
- Confirm whether the proposal has been approved before deciding how to handle any changes.
- Obtain the official Greenwich report template or its formatting requirements.

## Evidence and limitations

- The project contains one Level1 scene and scripts for state switching, zones, crystals, portal, checkpoint, traps, the Lumis lever, light shooting and Polarity Split.
- The pressure plate was attempted and its script was removed. An Umbra-blocked laser was discussed, but implementation has not been confirmed.
- Script availability alone does not establish that features are configured, fully tested, or complete in the level.
- Do not claim tests, user feedback, sources, results, or final features without evidence.

## Report references

- Smith, G., Cha, M. and Whitehead, J. (2008) 'A framework for analysis of 2D platformer levels', in Proceedings of the 2008 ACM SIGGRAPH Symposium on Video Games, pp. 75-80. doi: 10.1145/1401843.1401858.
  - Full text: https://eis.ucsc.edu/papers/smith-sandbox-08.pdf
  - Used for: Chapter 2.1, platformer level elements and their arrangement.
  - In-text citation: (Smith, Cha and Whitehead, 2008).
- Linehan, C., Bellord, G., Kirman, B., Morford, Z.H. and Roche, B. (2014) 'Learning curves: analysing pace and challenge in four successful puzzle games', in ACM SIGCHI Symposium on Play in Computer Human Interaction, pp. 181-190.
  - Research record and abstract: https://pure.york.ac.uk/portal/en/publications/learning-curves-analysing-pace-and-challenge-in-four-successful-p/
  - Proposed for: Chapter 2.1, the gradual introduction and combination of puzzle mechanics. Based on the published abstract; check the complete paper when developing detailed analysis.
  - In-text citation: (Linehan et al., 2014).
- Sicart, M. (2008) 'Defining game mechanics', Game Studies, 8(2).
  - Full text: https://www.gamestudies.org/0802/articles/sicart/
  - Proposed for: Chapter 2.2, game mechanics and interaction with game state.
  - In-text citation: (Sicart, 2008).
- Shokeen, E., Pellicone, A., Weintrop, D., Ketelhut, D.J., Williams-Pierce, C., Plane, J.D. and Cukier, M. (2020) 'Designing failure and feedback within puzzles', Extended Abstracts of the 2020 Annual Symposium on Computer-Human Interaction in Play. doi: 10.1145/3383668.3419901.
  - Full text: https://www.terpconnect.umd.edu/~weintrop/papers/Shokeen_et_al_CHI_PLAY_2020.pdf
  - Proposed for: Chapter 2.3, feedback and failure in puzzles. Preliminary findings from an educational cybersecurity game; do not generalize as proven for Rover.
  - In-text citation: (Shokeen et al., 2020).
- World Wide Web Consortium (W3C) (2023) Web Content Accessibility Guidelines (WCAG) 2.2, section 1.4.1, Use of Color. Available at: https://www.w3.org/TR/2023/REC-WCAG22-20231005/#use-of-color (Accessed: 26 November 2026).
  - Proposed for: Chapter 2.4, conveying information with more than colour. WCAG addresses web content; use as design inspiration for the game, not as a claim of compliance.
  - In-text citation: (W3C, 2023).
- Johanson, C., Piller, B., Gutwin, C. and Mandryk, R.L. (2023) 'If at first you don't succeed: helping players make progress in games with breaks and checkpoints', Proceedings of the ACM on Human-Computer Interaction, 7 (CHI PLAY), article 387. doi: 10.1145/3611033.
  - Full text: https://cjohanson.net/downloads/publications/2023%20-%20If%20at%20First%20You%20Dont%20Succeed.pdf
  - Proposed for: Chapter 2.5, checkpoints and retrying challenges. Results concern the platform game and participants studied, not a test of Rover.
  - In-text citation: (Johanson et al., 2023).
- Scozzi, M.V., Iacovides, I. and Linehan, C. (2017) 'A mixed method approach for evaluating and improving the design of learning in puzzle games', in The ACM SIGCHI Annual Symposium on Computer-Human Interaction in Play, pp. 217-228. doi: 10.1145/3116595.3116628.
  - Research record: https://pure.york.ac.uk/portal/en/publications/a-mixed-method-approach-for-evaluating-and-improving-the-design-o/
  - Proposed for: Chapter 2.6, player testing. The study concerns Portal and 14 participants, not Rover.
  - In-text citation: (Scozzi, Iacovides and Linehan, 2017).
- Unity Technologies (n.d.) '2D game creation workflow', Unity Manual, Unity 6.4. Available at: https://docs.unity3d.com/6000.4/Documentation/Manual/2d-game-creation-wokflow.html (Accessed: 26 November 2026).
  - Proposed for: Chapter 3.1, Unity 2D tools, components and development workflow. ProjectVersion.txt records editor 6000.4.8f1.
  - In-text citation: (Unity Technologies, n.d.).
- Unity Technologies (n.d.) 'Scripting', Unity Manual, Unity 6.4. Available at: https://docs.unity3d.com/6000.4/Documentation/Manual/scripting.html (Accessed: 26 November 2026).
  - Proposed for: Chapter 3.2, C# scripting in Unity. Assign distinct n.d.-a/n.d.-b labels to the Unity sources and update in-text citations consistently when assembling the bibliography.
- Unity Technologies (n.d.) 'Introduction to Rigidbody 2D', Unity Manual, Unity 6.4. Available at: https://docs.unity3d.com/6000.4/Documentation/Manual/2d-physics/rigidbody/introduction-to-rigidbody-2d.html (Accessed: 26 November 2026).
  - Proposed for: Chapter 3.3, Rigidbody2D and physics. Collider2D and trigger information also appears in the previously recorded '2D game creation workflow'. Assign distinct n.d. labels consistently when compiling references.
- Unity Technologies (n.d.) 'Input', Unity Scripting API, Unity 6.4. Available at: https://docs.unity3d.com/6000.4/Documentation/ScriptReference/Input.html (Accessed: 26 November 2026).
  - Proposed for: Chapter 3.5, legacy Input API. Current gameplay scripts use Input.GetAxisRaw and Input.GetKeyDown; the Input System package is installed but this alone does not establish gameplay usage. Assign distinct n.d. labels in the final reference list.
- GitHub (n.d.) 'What is GitHub?', GitHub Docs. Available at: https://docs.github.com/en/get-started/start-your-journey/what-is-github (Accessed: 26 November 2026).
  - Proposed for: Chapter 3.6, the distinction between Git and GitHub. In-text citation: (GitHub, n.d.).
- Unity Technologies (n.d.) 'TextMeshPro', Unity Manual, Unity 2021.1. Available at: https://docs.unity3d.com/2021.1/Documentation/Manual/com.unity.textmeshpro.html (Accessed: 26 November 2026).
  - Proposed for: Chapter 3.7, TextMesh Pro text formatting. This documentation describes an older Unity version; it does not establish the package version used by the project. Assign distinct n.d. labels consistently.
- Coolmath Games (n.d.) 'Fireboy and Watergirl in the Forest Temple'. Available at: https://www.coolmathgames.com/0-fireboy-and-water-girl-in-the-forest-temple (Accessed: 26 November 2026).
  - Proposed for: Chapter 4.1, element interactions, hazards and two-character puzzles. In-text citation: (Coolmath Games, n.d.).
- Nintendo (n.d.) 'Braid, Anniversary Edition', Nintendo Official Site. Available at: https://www.nintendo.com/us/store/products/braid-anniversary-edition-switch/ (Accessed: 26 November 2026).
  - Proposed for: Chapter 4.1, puzzle-platforming and time manipulation. This source describes the 2024 Anniversary Edition, not exclusively the original release. In-text citation: (Nintendo, n.d.).
- Amazon Web Services (n.d.) 'What is SDLC?', AWS. Available at: https://aws.amazon.com/what-is/sdlc/ (Accessed: 26 November 2026).
  - Proposed for: Chapter 5.1, the sequential stages of the Waterfall model. In-text citation: (Amazon Web Services, n.d.).
- Boehm, B.W. (1988) 'A spiral model of software development and enhancement', Computer, 21(5), pp. 61-72. doi: 10.1109/2.59.
  - Full text: https://faculty.washington.edu/hazeline/misc/reserve/boehm_spiralmodel.pdf
  - Proposed for: Chapter 5.2, Spiral as a risk-driven development model. In-text citation: (Boehm, 1988).
- Microsoft (n.d.) 'What is rapid application development (RAD)?', Microsoft Power Apps. Available at: https://www.microsoft.com/en-us/power-platform/topics/rapid-application-development (Accessed: 26 November 2026).
  - Proposed for: Chapter 5.3, rapid prototyping and user feedback in RAD. Project-specific user testing has not been confirmed. In-text citation: (Microsoft, n.d.).
- Beck, K. et al. (2001) 'Manifesto for Agile Software Development'. Available at: https://agilemanifesto.org/ (Accessed: 26 November 2026).
  - Principles: https://agilemanifesto.org/principles.html
  - Proposed for: Chapter 5.4, Agile values and principles. Iterative changes alone do not establish a formal Agile process. In-text citation: (Beck et al., 2001).

## Repository observation

- The project .gitignore lists generated Logs, Temp and UserSettings folders, but git status on 26 November 2026 showed some files in those folders are already tracked. Ignore rules do not stop tracking previously tracked files; review separately before changing the repository.
