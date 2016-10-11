var gulp = require('gulp')
var minify = require('gulp-minify-html')
var del = require('del')

gulp.task('minifyHtml', () => {
  del.sync(['build/*.html'])

  return gulp.src('./content/html/*.html')
    .pipe(minify())
    .pipe(gulp.dest('./build'))
})

gulp.task('default', ['minifyHtml'], function () { })
