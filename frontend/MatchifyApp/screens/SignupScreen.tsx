import React, { useState } from 'react';
import { View, Text, TextInput, Button, Alert, StyleSheet, TouchableOpacity } from 'react-native';
import { NativeStackNavigationProp } from '@react-navigation/native-stack';
import { useNavigation } from '@react-navigation/native';

// Define the navigation stack parameter types
type RootStackParamList = {
  Login: undefined;
  Signup: undefined;
};

// Type for navigation prop specific to Signup screen
type SignupScreenNavigationProp = NativeStackNavigationProp<RootStackParamList, 'Signup'>;

export default function SignupScreen() {
  // Get navigation object for screen transitions
  const navigation = useNavigation<SignupScreenNavigationProp>();

  // State variables for form fields and loading status
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);

  // Handles user signup logic
  const handleSignup = async () => {
    // Validate that all fields are filled
    if (!username || !email || !password) {
      Alert.alert('Please fill in all fields');
      return;
    }

    setLoading(true);
    try {
      // Send signup request to backend API
      const response = await fetch('http://localhost:8000/api/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, email, password }),
      });

      // Handle unsuccessful response
      if (!response.ok) {
        const errorData = await response.json();
        Alert.alert('Signup Failed', errorData.detail || 'Error during registration');
        setLoading(false);
        return;
      }

      // Show success message and navigate back to Login
      Alert.alert('Signup Success', 'Account created! You can now log in.');
      navigation.goBack();
    } catch (error) {
      // Handle network or server errors
      Alert.alert('Error', 'Could not connect to server.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Sign Up</Text>

      {/* Username input field */}
      <TextInput
        placeholder="Username"
        value={username}
        onChangeText={setUsername}
        autoCapitalize="none"
        style={styles.input}
      />
      {/* Email input field */}
      <TextInput
        placeholder="Email"
        value={email}
        onChangeText={setEmail}
        keyboardType="email-address"
        autoCapitalize="none"
        style={styles.input}
      />
      {/* Password input field */}
      <TextInput
        placeholder="Password"
        value={password}
        onChangeText={setPassword}
        secureTextEntry
        style={styles.input}
      />

      {/* Signup button */}
      <Button title={loading ? 'Signing up...' : 'Sign Up'} onPress={handleSignup} disabled={loading} />

      {/* Link to go back to Login screen */}
      <TouchableOpacity onPress={() => navigation.goBack()} style={{ marginTop: 20 }}>
        <Text style={{ color: '#0284c7', textAlign: 'center' }}>Already have an account? Login</Text>
      </TouchableOpacity>
    </View>
  );
}

// Styles for the signup screen components
const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: 'center', padding: 20 },
  title: { fontSize: 24, marginBottom: 20, textAlign: 'center' },
  input: {
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    marginBottom: 12,
    paddingHorizontal: 10,
    borderRadius: 5,
  },
});
