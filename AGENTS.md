# Source publication instructions

The user has authorized routine publication of every future tested source change: push the private `Fogzza/SolarNet-source` checkpoint first, then publish a matching natural development note to the private `Fogzza/SolarNet-updates` repository. Follow that order and require both repositories to remain private. Notes and commit titles are shared with the Discord channel, so never include source, diffs, credentials, forensic incident details, or local paths in updates.

1. Make and test the intended source change in the working RR23 project. Run checks appropriate to the change and state their actual limits. A source compile or small Windows fixture is not a full-game build.
2. Refresh the code-only publication manifest and review its redacted credential findings. Include all approved actual source, SDK/compiler support, settings, package manifests, and original retained file/folder metadata. Exclude unlisted original scenes, art, audio, StreamingAssets, builds, logs, caches, and backend/private captures. Do not broaden scope with a recursive copy.
3. Update the ignored local publisher config with the fresh manifest and reviewed SHA. Write the development note yourself in an ignored local note file, suitable for the Discord channel. Use a factual title and a private test summary; do not generate claims from file counts or a successful commit.
4. Preview `tools/publish_tested_source.py`, inspect its bounded summary, then run it with `--publish`, the explicit title, note file, and test summary. It must verify both repositories are private and confirm private source was pushed before committing or pushing the private update.
5. If interrupted, inspect the ignored pending ledger and use explicit `--resume` with the same inputs. Never force-push, overwrite independent edits, reset someone else's staging, or blindly retry an ambiguous commit/push. Report any blocker concretely.

Use the fixed noreply author `Fogzza <177904833+Fogzza@users.noreply.github.com>`. Let Git use its configured Git Credential Manager. Never print, store, copy, or commit authentication tokens. The publisher checks exact repository remotes and both-private GitHub visibility before publication; it must not change repository visibility.

The updates repository permits only `README.md`, `CHANGELOG.md`, `.gitignore`, and `.gitattributes`. Preserve its existing setup documentation; the normal publisher appends the supplied prose to the changelog. Keep the existing standard GitHub-compatible Discord webhook in the updates repository's GitHub configuration. Notifications remain clickable, and repository viewing requires authorized GitHub access. Do not replace the hook with direct Discord delivery. Never add its URL or secret to files, commits, notes, or logs.

Keep `.publisher.local.json`, state, pending ledgers, notes, and caches ignored. The initial snapshot can be copied from an exact reviewed manifest and committed by the coordinating agent; run `--initialize` afterward to record file ownership for safe future removals.

## User-managed documentation — November 3, 2026

The user asked to remove README and CHANGELOG files and will write the documentation. This overrides the earlier automatic-note and setup-document preservation requirements. The approved removal is the source repository's root `README.md` and the updates repository's root `README.md` and `CHANGELOG.md`.

Use the publisher's explicit `--remove-readme-changelog` mode for that removal. For later publications, use `--no-generated-note` to preserve any documentation the user writes; do not regenerate README or CHANGELOG content. A matching title-only updates commit may be empty when there is no document change. Keep the factual title and actual test summary, preview first, and push private source before the matching private updates commit. Both repositories must remain private. All source-manifest, credential, staging and resume safeguards still apply.
