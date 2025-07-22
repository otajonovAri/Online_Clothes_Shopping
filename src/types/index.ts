export interface User {
  id: string
  email: string
  firstName: string
  lastName: string
  role: 'student' | 'instructor' | 'admin'
  avatar?: string
  createdAt: string
  updatedAt: string
}

export interface Student extends User {
  role: 'student'
  enrolledCourses: Course[]
  completedCourses: Course[]
  progress: CourseProgress[]
}

export interface Instructor extends User {
  role: 'instructor'
  bio: string
  expertise: string[]
  courses: Course[]
  rating: number
  totalStudents: number
}

export interface Course {
  id: string
  title: string
  description: string
  shortDescription: string
  thumbnail: string
  price: number
  duration: number // in hours
  level: 'beginner' | 'intermediate' | 'advanced'
  category: string
  tags: string[]
  instructorId: string
  instructor: Instructor
  lessons: Lesson[]
  enrolledStudents: number
  rating: number
  reviews: Review[]
  createdAt: string
  updatedAt: string
}

export interface Lesson {
  id: string
  title: string
  description: string
  videoUrl: string
  duration: number // in minutes
  order: number
  courseId: string
  isCompleted?: boolean
}

export interface Review {
  id: string
  rating: number
  comment: string
  studentId: string
  student: Student
  courseId: string
  createdAt: string
}

export interface CourseProgress {
  id: string
  studentId: string
  courseId: string
  completedLessons: string[]
  progress: number // percentage
  lastAccessedAt: string
}

export interface ApiResponse<T> {
  data: T
  message: string
  success: boolean
}

export interface PaginatedResponse<T> {
  data: T[]
  total: number
  page: number
  limit: number
  totalPages: number
}

export interface LoginRequest {
  email: string
  password: string
}

export interface RegisterRequest {
  email: string
  password: string
  firstName: string
  lastName: string
  role: 'student' | 'instructor'
}

export interface AuthResponse {
  user: User
  token: string
}