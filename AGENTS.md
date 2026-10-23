# Source publication instructions

The user has authorized routine publication of every future tested source change: push the private `Fogzza/SolarNet-source` checkpoint first, then publish a matching natural development note to `Fogzza/SolarNet-updates`. Follow that order. Do not put source, diffs, credentials, forensic incident details, or local paths in the public repository.

1. Make and test the intended source change in the working RR23 project. Run checks appropriate to the change and state their actual limits. A source compile or small Windows fixture is not a full-game build.
2. Refresh the code-only publication manifest and review its redacted credential findings. Include all approved actual source, SDK/compiler support, settings, package manifests, and original retained file/folder metadata. Exclude unlisted original scenes, art, audio, StreamingAssets, builds, logs, caches, and backend/private captures. Do not broaden scope with a recursive copy.
3. Update the ignored local publisher config with the fresh manifest and reviewed SHA. Write the public note yourself in an ignored local note file. Use a factual title and a private test summary; do not generate claims from file counts or a successful commit.
4. Preview `tools/publish_tested_source.py`, inspect its bounded summary, then run it with `--publish`, the explicit title, note file, and test summary. It must confirm private source was pushed before committing or pushing the public update.
5. If interrupted, inspect the ignored pending ledger and use explicit `--resume` with the same inputs. Never force-push, overwrite independent edits, reset someone else's staging, or blindly retry an ambiguous commit/push. Report any blocker concretely.

Use the fixed noreply author `Fogzza <177904833+Fogzza@users.noreply.github.com>`. Let Git use its configured Git Credential Manager. Never print, store, copy, or commit authentication tokens. The publisher checks exact repository remotes and private/public GitHub visibility before publication.

Public updates permit only `README.md`, `CHANGELOG.md`, `.gitignore`, and `.gitattributes`. Preserve existing public setup documentation; the normal publisher appends the supplied prose to the changelog. The standard GitHub-compatible Discord webhook belongs only to the public updates repository's GitHub configuration. Never add its URL or secret to files, commits, notes, or logs.

Keep `.publisher.local.json`, state, pending ledgers, notes, and caches ignored. The initial snapshot can be copied from an exact reviewed manifest and committed by the coordinating agent; run `--initialize` afterward to record file ownership for safe future removals.
